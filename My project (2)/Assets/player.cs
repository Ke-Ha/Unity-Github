using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Animator anim = null;
    // Start is called before the first frame update
    void Start()
    {
        Animation=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
