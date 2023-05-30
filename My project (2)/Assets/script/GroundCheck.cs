using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [Header("�G�t�F�N�g���������𔻒肷�邩")] public bool checkPlatformGround = true;

    private string groundTag = "Ground";
    private string platformTag = "GroundPlatform";
    private string moveFloorTag = "MoveFloor";

    private bool isGround=false;
    private bool isGroundEnter, isGroundStay,isGroundExit;

    public bool IsGround()
    {
        if(isGroundEnter || isGroundStay)
        {
            isGround=true;
        }
        else if (isGroundExit)
        {
            isGround=false;
        }

        isGroundEnter=false;
        isGroundStay=false;
        isGroundExit=false;
        return isGround;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == groundTag)
        {
            isGroundEnter=true;
        }else if(checkPlatformGround && collision.tag == platformTag || collision.tag==moveFloorTag)
        {
            isGroundEnter = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == groundTag)
        {
            isGroundStay=true;
        }
        else if (checkPlatformGround && collision.tag == platformTag || collision.tag==moveFloorTag)
        {
            isGroundStay = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == groundTag)
        {
            isGroundExit=true;
        }
        else if (checkPlatformGround && collision.tag == platformTag || collision.tag == moveFloorTag)
        {
            isGroundExit = true;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
