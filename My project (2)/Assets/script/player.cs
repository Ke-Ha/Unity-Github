using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    #region //public�ϐ��i�V���A�����j
    [Header("�ړ����x")]public float speed;
    [Header("�d��")] public float gravity;
    [Header("�W�����v���x")] public float jumpSpeed;
    [Header("�W�����v���鍂��")] public float jumpHeight;
    [Header("�W�����v��������")] public float jumpLimitTime;
    [Header("���݂�����̍����̊���")] public float stepOnRate;


    [Header("�ڒn����")] public GroundCheck ground;
    [Header("�����Ԃ�������")] public GroundCheck head;

    [Header("�_�b�V���̑����\��")] public AnimationCurve dashCurve;
    [Header("�W�����v�̑����\��")] public AnimationCurve jumpCurve;
    #endregion

    #region//private�ϐ�
    private Rigidbody2D rb = null;
    private Animator anim = null;
    private CapsuleCollider2D capcol = null;

    private bool isGround = false;
    private bool isHead = false;
    private bool isJump = false;
    private bool isWalk = false;
    private bool isDown = false;
    private bool isOtherJump = false;

    private string enemyTag = "Enemy";

    private float jumpPos = 0.0f;
    private float otherJumpHeight = 0.0f;
    private float dashTime,jumpTime;
    private float beforeKey;
    #endregion

    void Start()
    {
        anim=GetComponent<Animator>();
        rb=GetComponent<Rigidbody2D>();
        capcol = GetComponent<CapsuleCollider2D>();
    }

    void FixedUpdate()
    {
        if (!isDown)
        {

            isGround = ground.IsGround();
            isHead = head.IsGround();

            float xSpeed = GetXSpeed();
            float ySpeed = GetYSpeed();

            SetAnimation();

            rb.velocity = new Vector2(xSpeed, ySpeed);
        }
        else
        {
            rb.velocity = new Vector2(0, -gravity);
        }
    }

    ///<summary>
    ///Y�����ŕK�v�Ȍv�Z�����A���x��Ԃ��B
    /// </summary>
    /// <returns>Y���̑���</returns>
    private float GetYSpeed()
    {
        float verticalKey = Input.GetAxis("Vertical");
        float ySpeed = -gravity;

        //�����𓥂񂾂Ƃ��̃W�����v
        if (isOtherJump)
        {
            //���݂̍�������ׂ鍂����艺��
            bool canHeight = jumpPos + otherJumpHeight > transform.position.y;
            //�W�����v���Ԃ������Ȃ肷���Ă��Ȃ���
            bool canTime = jumpLimitTime > jumpTime;

            if (canHeight && canTime && !isHead)
            {
                ySpeed = jumpSpeed;
                jumpTime += Time.deltaTime;
            }
            else
            {
                isOtherJump = false;
                jumpTime=0.0f;
            }

        }
        if (isGround)
        {
            if (verticalKey > 0)
            {
                ySpeed = jumpSpeed;
                jumpPos = transform.position.y; //�W�����v�����ʒu���L�^����
                isJump = true;
                jumpTime = 0.0f;
            }
            else
            {
                isJump = false;
            }
        }
        else if (isJump)
        {
            //������L�[�������Ă��邩
            bool pushUpKey = verticalKey > 0;
            //���݂̍�������ׂ鍂����艺��
            bool canHeight = jumpPos + jumpHeight > transform.position.y;
            //�W�����v���Ԃ������Ȃ肷���ĂȂ���
            bool canTime = jumpLimitTime > jumpTime;

            if (pushUpKey && canHeight && canTime && !isHead)
            {
                ySpeed = jumpSpeed;
                jumpTime += Time.deltaTime;
            }
            else
            {
                isJump = false;
                jumpTime = 0.0f;
            }
        }

        if (isJump)
        {
            ySpeed *= jumpCurve.Evaluate(jumpTime);
        }

        return ySpeed;
   
    }
      

    ///<summary>
    ///X�����ŕK�v�Ȍv�Z�����A���x��Ԃ��B
    /// </summary>
    /// <returns>X���̑���</returns>
    private float GetXSpeed()
    {
        float horizontalKey = Input.GetAxis("Horizontal");
        float xSpeed = 0.0f;

        if (horizontalKey > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            isWalk = true;
            dashTime += Time.deltaTime;
            xSpeed = speed;
        }
        else if (horizontalKey < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            isWalk = true;
            dashTime += Time.deltaTime;
            xSpeed = -speed;
        }
        else
        {
            isWalk = false;
            xSpeed = 0.0f;
            dashTime = 0.0f;
        }

        //�O��̓��͂���_�b�V���̔��]�𔻒f���đ��x��ς���
        if (horizontalKey > 0 && beforeKey < 0)
        {
            dashTime = 0.0f;
        }
        else if (horizontalKey < 0 && beforeKey > 0)
        {
            dashTime = 0.0f;
        }

        beforeKey = horizontalKey;
        xSpeed *= dashCurve.Evaluate(dashTime);
        beforeKey = horizontalKey;
        return xSpeed;
    }

    ///<summary>
    ///�A�j���[�V������ݒ肷��
    /// </summary>
    private void SetAnimation()
    {
        anim.SetBool("jump", isJump || isOtherJump);
        anim.SetBool("ground", isGround);
        anim.SetBool("walk", isWalk);
    }

    #region//�ڐG����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == enemyTag)
        {
            //���݂�����ɂȂ鍂��
            float stepOnHeight = (capcol.size.y * (stepOnRate / 100f));
            //���݂�����̃��[���h���W
            float judgePos = transform.position.y + stepOnHeight;

            foreach(ContactPoint2D p in collision.contacts)
            {
                if (p.point.y < judgePos)
                {
                    ObjectCollision o = collision.gameObject.GetComponent<ObjectCollision>();
                    if (o != null)
                    {
                        otherJumpHeight = o.boundHeight;
                        //���񂾑��肩�璵�˂鍂�����擾����

                        o.playerStepOn = true;
                        //���񂾑���ɑ΂��ē��񂾎���ʒm����

                        jumpPos = transform.position.y;
                        //�W�����v�����ʒu���L�^����

                        isOtherJump = true;
                        isJump = false;
                        jumpTime = 0.0f;
                    }
                    else
                    {
                        Debug.Log("ObjectCollision�����ĂȂ��I");
                    }
                }
                else
                {
                    anim.Play("player_down");
                    isDown = true;
                    break;
                }
            }
            
        }
    }
    #endregion

    

}

