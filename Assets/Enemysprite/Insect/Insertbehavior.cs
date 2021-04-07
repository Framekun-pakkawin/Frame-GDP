using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insertbehavior : MonoBehaviour
{
    public float basespeed;
    public float delayspeed;
    float speed;
    private float waitTime;
    public float startWaitTime;

    [HideInInspector]public float distanceforplayer = 3.5f;

    public Transform moveSpot;
    public Rigidbody2D beanRigid;

    public bool isAttacking = false; 

    public float patroldistance = 5.0f;
    private float minX;
    private float maxX;
    private float minY;

    public BeanSight sightBehavior;

    void Start()
    {
        speed = basespeed;
        waitTime = 0f;
        minY = gameObject.transform.position.y;
        minX = gameObject.transform.position.x - 5;
        maxX = gameObject.transform.position.x + 5;
        moveSpot.position = new Vector2(minX, transform.position.y);
    }

    void FixedUpdate()
    {
        if (isAttacking == true)
        {
            speed = delayspeed;
        }
        else
        {
            speed = basespeed;
        }
        Transform currentSpot = moveSpot;
        moveSpot.position = new Vector3(currentSpot.position.x, transform.position.y, currentSpot.position.z);
        //moveSpot.position = new Vector3(moveSpot.position.x, minY, moveSpot.position.z);
        if (sightBehavior.targetPlayerToChase == null)
        {
            Patrol_Behavior();
        }
        else
        {
            Chase_Player(speed);
        }

        //Chase_Player();
    }

    // Update is called once per frame
    void Patrol_Behavior()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpot.position) < 0.1f)
        {
            if (waitTime >= 0f && waitTime <= startWaitTime)
            {
                moveSpot.position = new Vector2(minX, minY);
                Transform currtrans = gameObject.transform;
                transform.localScale = new Vector3(Mathf.Abs(currtrans.localScale.x), currtrans.localScale.y, currtrans.localScale.z);
            }
            else if (waitTime > startWaitTime)
            {
                moveSpot.position = new Vector2(maxX, minY);
                Transform currtrans = gameObject.transform;
                transform.localScale = new Vector3(-Mathf.Abs(currtrans.localScale.x), currtrans.localScale.y, currtrans.localScale.z);
            }
            waitTime += Time.deltaTime;

            if (waitTime >= startWaitTime * 2)
            {
                waitTime = 0f;
            }
        }
    }

    void Chase_Player(float speed)
    {
        Vector3 targetPosition = sightBehavior.targetPlayerToChase.transform.position;
        Vector3 currentPosition = gameObject.transform.position;


        if (targetPosition.x < currentPosition.x)
        {
            if (Mathf.Abs(currentPosition.x - targetPosition.x) > distanceforplayer)
            {
                beanRigid.velocity = -transform.right * speed;
            }
            else
            {
                beanRigid.velocity = transform.right * 0;
            }
            Transform currtrans = gameObject.transform;
            transform.localScale = new Vector3(Mathf.Abs(currtrans.localScale.x), currtrans.localScale.y, currtrans.localScale.z);
        }
        else if (targetPosition.x > currentPosition.x)
        {
            if (Mathf.Abs(currentPosition.x - targetPosition.x) > distanceforplayer)
            {
                beanRigid.velocity = transform.right * speed;
            }
            else
            {
                beanRigid.velocity = transform.right * 0;
            }
            Transform currtrans = gameObject.transform;
            transform.localScale = new Vector3(-Mathf.Abs(currtrans.localScale.x), currtrans.localScale.y, currtrans.localScale.z);
        }
    }
}
