using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletsaber : MonoBehaviour
{
    public float speed = 20.0f;
    public float bulletdamage = 5.0f;
    public float distance = 50.0f;
    public int countdown = 50;
    Rigidbody2D rb;
    Transform starttrans;
    void Start()
    {
        starttrans = GetComponent<Transform>();
        starttrans.position = gameObject.transform.position;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }
    void Update()
    {
        if(countdown <= 0)
        {
            Destroy(gameObject);
        }
        if (Mathf.Abs(starttrans.position.x - gameObject.transform.position.x) >= distance)
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        if (countdown > 0)
        {
            countdown -= 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Spirit") == true)
        {
            EnemyStatus enemy = hitInfo.GetComponent<EnemyStatus>();
            enemy.TakeDamage(bulletdamage);
            Destroy(gameObject);
        }
    }
}
