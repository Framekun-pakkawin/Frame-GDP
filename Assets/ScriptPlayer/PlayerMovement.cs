using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public CharacterSwitch characterswitch;
    public float horizontalmove = 0.0f;
    public float runspeed = 3.0f;
    public HealthBar healthBar;
    public PlayerHp playerhp;
    public bool isplayer2 = false;
    public bool knockbackright = false;

    [HideInInspector]
    public bool isFacingright = true;
    public bool jump = false;
    public bool isMoving = false;
    public bool isAttacking = false;
    public bool isGround = true;


    void Start()
    {

    }

    void Update()
    {
        if (characterswitch.IsControling == true)
        {
            if (isplayer2 == false)
            {
                horizontalmove = Input.GetAxisRaw("Horizontal") * runspeed;
                if (Input.GetButtonDown("Jump"))
                {
                    jump = true;
                }
            }
            else
            {
                horizontalmove = Input.GetAxisRaw("Horizontal2") * runspeed;
                if (Input.GetButtonDown("Jump2"))
                {
                    jump = true;
                }
            }
            
        }
        
    }

    void FixedUpdate()
    {
        controller.Move(horizontalmove * Time.deltaTime,false,jump);
        jump = false;
        if (horizontalmove > 0)
        {
            isMoving = true;
            isFacingright = true;
        }
        else if (horizontalmove < 0)
        {
            isMoving = true;
            isFacingright = false;
        }
        else
        {
            isMoving = false;
        }
    }
    public void TakeDamage(float damage)
    {
        playerhp.currentHealth -= damage;
        healthBar.SetHealth(playerhp.currentHealth);
    }
    public void knockback(float forceX, float forceY)
    {
        if (knockbackright == false)
        {
            forceX = -forceX;
        }
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(forceX, forceY));
    }
}
