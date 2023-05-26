using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Zako1 : MonoBehaviour
{
    #region//�C���X�y�N�^�[�Őݒ肷��
    [Header("�ړ����x")] public float speed;
    [Header("�d��")] public float gravity;
    [Header("��ʊO�ł��s������")] public bool nonVisibleAct;
<<<<<<< HEAD
    [Header("�ڐG����")] public EnemyCollisionCheck checkCollision;
=======
>>>>>>> ab63c79990d5270d85928a9053542025f4af5e5d
    #endregion

    #region//�v���C�x�[�g�ϐ�
    private Rigidbody2D rb = null;
    private SpriteRenderer sr = null;
<<<<<<< HEAD
    private Animator anim = null;
    private ObjectCollision oc = null;
    private BoxCollider2D col = null;

    private bool rightTleftF = false;
    private bool isDown = false;

=======
    private bool rightTleftF = false;
>>>>>>> ab63c79990d5270d85928a9053542025f4af5e5d
    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
<<<<<<< HEAD
        anim = GetComponent<Animator>();
        oc = GetComponent<ObjectCollision>();
        col = GetComponent<BoxCollider2D>();
=======
>>>>>>> ab63c79990d5270d85928a9053542025f4af5e5d
    }

    void FixedUpdate()
    {
<<<<<<< HEAD
        if (!oc.playerStepOn)
        {
            if (sr.isVisible || nonVisibleAct)
            {
                if (checkCollision.isOn)
                {
                    rightTleftF = !rightTleftF;
                }
                int xVector = -1;
                if (rightTleftF)
                {
                    xVector = 1;
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
                rb.velocity = new Vector2(xVector * speed, -gravity);
            }
            else
            {
                rb.Sleep();
            }
        }
        else
        {
            if (!isDown)
            {
                anim.Play("enemy_zako1_down");
                rb.velocity = new Vector2(0, -gravity);
                isDown = true;
                col.enabled = false;
                Destroy(gameObject,3f);
            }
            else
            {
                transform.Rotate(new Vector3(0, 0, 5));
            }
=======
        if (sr.isVisible || nonVisibleAct) 
        {
            int xVector = -1;
            if (rightTleftF)
            {
                xVector = 1;
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            rb.velocity = new Vector2(xVector * speed, -gravity);
        }
        else
        {
            rb.Sleep();
>>>>>>> ab63c79990d5270d85928a9053542025f4af5e5d
        }
    }
}
