using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewFirespiritsBehavior : MonoBehaviour
{
    public Transform target;
    public float speed = 20.0f;
    public float patrolspeed = 8.0f;
    public float delay = 1.0f;
    public float patroldistance = 10.0f;
    public float Waittime = 1.0f;
    bool onMovingright = false;
    bool isPatroling = false;
    bool isDelaying = false;
    bool isFacingRight = false;
    float startpatrolposX;
    Rigidbody2D rigid;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        startpatrolposX = (float)gameObject.transform.position.x;
    }


    void Update()
    {
        if (target == null)
        {
            Patrol();
        }
        else
        {
            Chasing();
            
        }
    }
    void Patrol()
    {
        if (!isPatroling)
        {
            if (onMovingright)
            {
                rigid.velocity = transform.right * patrolspeed;
                if (Mathf.Abs(startpatrolposX - gameObject.transform.position.x) >= patroldistance)
                {
                    startpatrolposX = gameObject.transform.position.x;
                    Transform currtrans = gameObject.transform;
                    transform.localScale = new Vector3(Mathf.Abs(currtrans.localScale.x), currtrans.localScale.y, currtrans.localScale.z);
                    onMovingright = false;
                    StartCoroutine(DelayPatrol());
                }
            }
            else
            {
                rigid.velocity = -transform.right * patrolspeed;
                if (Mathf.Abs(startpatrolposX - gameObject.transform.position.x) >= patroldistance)
                {
                    startpatrolposX = gameObject.transform.position.x;
                    Transform currtrans = gameObject.transform;
                    transform.localScale = new Vector3(-Mathf.Abs(currtrans.localScale.x), currtrans.localScale.y, currtrans.localScale.z);
                    onMovingright = true;
                    StartCoroutine(DelayPatrol());
                }
            }
        }
    }
    void Chasing()
    {
        if (isFacingRight && (gameObject.transform.position.x > target.position.x))
        {
            Transform currtrans = gameObject.transform;
            transform.localScale = new Vector3(Mathf.Abs(currtrans.localScale.x), currtrans.localScale.y, currtrans.localScale.z);
            isFacingRight = false;
        }
        else if (!isFacingRight && (gameObject.transform.position.x < target.position.x))
        {
            Transform currtrans = gameObject.transform;
            transform.localScale = new Vector3(-Mathf.Abs(currtrans.localScale.x), currtrans.localScale.y, currtrans.localScale.z);
            isFacingRight = true;
        }
        if (!isDelaying)
        {
            StartCoroutine(Attacking());
        }
    }
    IEnumerator DelayPatrol()
    {
        isPatroling = true;
        rigid.velocity = transform.right * 0;
        yield return new WaitForSeconds(Waittime);
        isPatroling = false;
    }
    IEnumerator Attacking()
    {
        if (!isDelaying)
        {
            isDelaying = true;
            rigid.velocity = new Vector3(0, 0, 0);
            yield return new WaitForSeconds(delay);
            rigid.velocity = (target.position - gameObject.transform.position).normalized *speed;
            yield return new WaitForSeconds(delay);
            isDelaying = false;
        }
    }
}
