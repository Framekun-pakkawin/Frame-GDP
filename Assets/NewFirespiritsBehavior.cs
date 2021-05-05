using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewFirespiritsBehavior : MonoBehaviour
{
    public Transform target;
    public float speed = 20.0f;
    public float delay = 1.0f;
    public float patroldistance = 5.0f;
    bool isDelaying = false;
    bool isFacingRight = false;
    Rigidbody2D rigid;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
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
        
    }
    void Chasing()
    {
        if (isFacingRight && (gameObject.transform.position.x > target.position.x))
        {
            gameObject.transform.Rotate(0f, 180f, 0f);
            isFacingRight = false;
        }
        else if (!isFacingRight && (gameObject.transform.position.x < target.position.x))
        {
            gameObject.transform.Rotate(0f, 180f, 0f);
            isFacingRight = true;
        }
        if (!isDelaying)
        {
            StartCoroutine(Attacking());
        }
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
