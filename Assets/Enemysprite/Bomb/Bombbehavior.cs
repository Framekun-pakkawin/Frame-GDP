using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombbehavior : MonoBehaviour
{
    public Transform target = null;
    public float movespeed = 5.0f;
    public float turndelay = 0.7f;
    bool MovingRight = false;
    float startpositionX;
    Rigidbody2D rb;
    public float Patroldistance = 10.0f;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        startpositionX = gameObject.transform.position.x;
    }


    void Update()
    {
        if (target != null)
        {
            Chasing();
        }
        else 
        {
            Patrol();
        }
    }
    void Patrol()
    {
        if (MovingRight)
        {
            rb.velocity = transform.right * movespeed;
            Transform currtrans = gameObject.transform;
            transform.localScale = new Vector3(-Mathf.Abs(currtrans.localScale.x), currtrans.localScale.y, currtrans.localScale.z);
        }
        else
        {
            rb.velocity = -transform.right * movespeed;
            Transform currtrans = gameObject.transform;
            transform.localScale = new Vector3(Mathf.Abs(currtrans.localScale.x), currtrans.localScale.y, currtrans.localScale.z);
        }
        if (Mathf.Abs(startpositionX - gameObject.transform.position.x) >= Patroldistance)
        {
            MovingRight = true;
        }
        else if ((startpositionX - gameObject.transform.position.x) <= 0)
        {
            MovingRight = false;
        }
    }
    void Chasing()
    {
        if (target.position.x > gameObject.transform.position.x)
        {
            rb.velocity = transform.right * movespeed;
        }
        else if (target.position.x < gameObject.transform.position.x)
        {
            rb.velocity = -transform.right * movespeed;
        }
    }
    
}
