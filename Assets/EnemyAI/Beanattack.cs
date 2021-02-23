using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beanattack : MonoBehaviour
{
    public float enemydamage = 5.0f;
    Rigidbody2D rb;
    float knowbackX = 500.0f;
    float knowbackY = 200.0f;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player"))
        {
            PlayerMovement player = hitInfo.gameObject.GetComponent<PlayerMovement>();
            player.TakeDamage(enemydamage);
            knowback(knowbackX, knowbackY);
        }
    }
    void knowback(float forceX,float forceY)
    {
        rb.AddForce(new Vector2(forceX, forceY));
    }
}
