using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletsaber : MonoBehaviour
{
    public float speed = 20.0f;
    public Rigidbody2D rb;
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        
        Destroy(gameObject);
    }
}
