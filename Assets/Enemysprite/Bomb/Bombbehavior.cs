using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombbehavior : MonoBehaviour
{
    public Transform target = null;
    public float movespeed = 5.0f;
    public float turndelay = 0.7f;
    public BombAttack bombattack;
    bool MovingRight = false;
    bool isKaboom = false;
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
        if (!isKaboom)
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
    }
    void Patrol()
    {
        if (MovingRight)
        {
            rb.velocity = new Vector3(movespeed, rb.velocity.y, 0.0f);
            //rb.velocity = transform.right * movespeed;
            Transform currtrans = gameObject.transform;
            transform.localScale = new Vector3(-Mathf.Abs(currtrans.localScale.x), currtrans.localScale.y, currtrans.localScale.z);
        }
        else
        {
            rb.velocity = new Vector3(-movespeed, rb.velocity.y, 0.0f);
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
            rb.velocity = new Vector3(movespeed, rb.velocity.y, 0.0f);
            Transform currtrans = gameObject.transform;
            transform.localScale = new Vector3(-Mathf.Abs(currtrans.localScale.x), currtrans.localScale.y, currtrans.localScale.z);
        }
        else if (target.position.x < gameObject.transform.position.x)
        {
            rb.velocity = new Vector3(-movespeed, rb.velocity.y, 0.0f);
            Transform currtrans = gameObject.transform;
            transform.localScale = new Vector3(Mathf.Abs(currtrans.localScale.x), currtrans.localScale.y, currtrans.localScale.z);
        }
    }
    private void OnCollisionEnter2D(Collision2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player"))
        {
            PlayerMovement playermove = hitInfo.gameObject.GetComponent<PlayerMovement>();
            if (!playermove.isDamaged)
            {
                bombattack.AttackAnim();
                isKaboom = true;
            }
        }
    }
    private void OnCollisionStay2D(Collision2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player"))
        {
            PlayerMovement playermove = hitInfo.gameObject.GetComponent<PlayerMovement>();
            if (!playermove.isDamaged)
            {
                bombattack.AttackAnim();
                isKaboom = true;
            }
        }
    }

}
