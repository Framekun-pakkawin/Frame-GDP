using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletsaber : MonoBehaviour
{
    public float speed = 20.0f;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Enemy") == true)
        {   

            Destroy(gameObject);
        }
    }
}
