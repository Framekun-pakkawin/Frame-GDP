using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    float horizontalmove = 0.0f;
    public float runspeed = 3.0f;
    bool jump = false;
    void Start()
    {
        
    }

    void Update()
    {
        horizontalmove = Input.GetAxisRaw("Horizontal")* runspeed;
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalmove * Time.deltaTime,false,jump);
        jump = false;
    }
}
