using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public CharacterSwitch characterswitch;
    float horizontalmove = 0.0f;
    public float runspeed = 3.0f;
    public HealthBar healthBar;
    public float maxHealth = 100;
    public float currentHealth;
    bool jump = false;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
        if (characterswitch.IsControling == true)
        {
            horizontalmove = Input.GetAxisRaw("Horizontal") * runspeed;
            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
            }
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalmove * Time.deltaTime,false,jump);
        jump = false;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
