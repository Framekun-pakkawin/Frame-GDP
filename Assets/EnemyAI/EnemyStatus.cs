﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public float Enemyhp = 20.0f;
    public bool knockbackright = true;
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
    public void TakeDamage(float Damage)
    {
        Enemyhp -= Damage;
        if (Enemyhp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    public void knockback(float forceX, float forceY)
    {
        if (knockbackright == false)
        {
            forceX = -forceX;
        }
        rb.AddForce(new Vector2(forceX, forceY));
    }
}
