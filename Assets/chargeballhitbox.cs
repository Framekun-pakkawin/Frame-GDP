using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chargeballhitbox : MonoBehaviour
{
    public float speed = 20.0f;
    public float distance = 50.0f;
    public float countdown = 1.0f;
    bool isDestorying = false;
    bool ishiting = false;
    EnemyStatus enemy;
    Transform enemyposition;
    Animator anim;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rb.velocity = transform.right * speed;
    }
    void Update()
    {
        StartCoroutine(Destorying());
        if (ishiting)
        {
            gameObject.transform.position = enemyposition.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Spirit") == true)
        {
            enemyposition = hitInfo.transform;
            enemy = hitInfo.GetComponent<EnemyStatus>();
            anim.SetBool("isHiting",true);
            rb.velocity = transform.right * 0;
            ishiting = true;
        }
    }
    public void DestroyObject()
    {
        Destroy(gameObject);
    }
    IEnumerator Destorying()
    {
        if (!isDestorying)
        {
            isDestorying = true;
            yield return new WaitForSeconds(countdown);
            isDestorying = false;
            Destroy(gameObject);
        }
    }
}
