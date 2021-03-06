﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanPatrol : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform moveSpot;
    public Rigidbody2D beanRigid;
    public Transform target;

    public float patroldistance = 5.0f;
    //public Transform startSpot;
    private float minX;
    private float maxX;
    private float minY;
    //public float maxY;
    //Vector3 startPatrolPosition;

    public BeanSight sightBehavior;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = 0f;
        minY = gameObject.transform.position.y;
        //startPatrolPosition = gameObject.transform.position;
        minX = gameObject.transform.position.x - 5;
        maxX = gameObject.transform.position.x + 5;
        moveSpot.position = new Vector2(minX, transform.position.y);
    }

    void FixedUpdate()
    {
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
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        

        if (targetPosition.x < currentPosition.x)
        {
            Transform currtrans = gameObject.transform;
            transform.localScale = new Vector3(Mathf.Abs(currtrans.localScale.x), currtrans.localScale.y, currtrans.localScale.z);
        }
        else if (targetPosition.x > currentPosition.x)
        {
            Transform currtrans = gameObject.transform;
            transform.localScale = new Vector3(-Mathf.Abs(currtrans.localScale.x), currtrans.localScale.y, currtrans.localScale.z);
        }
    }
}
