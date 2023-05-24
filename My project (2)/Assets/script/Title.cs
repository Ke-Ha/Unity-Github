using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    private bool firstPush = false;

    public void PressStart()
    {
        Debug.Log("Press Start!");
        if (!firstPush)
        {
            Debug.Log("Go Next Scene!");
            {
                //Ÿ‚ÌƒV[ƒ“‚Ös‚­ˆ—

                firstPush = true;
            }

        }
    }
    void Start()

    {
        
    }

    
    void Update()
    {
        
    }
}
