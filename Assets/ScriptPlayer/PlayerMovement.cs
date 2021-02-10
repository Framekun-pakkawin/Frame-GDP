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
    public PlayerHp playerhp;
    bool jump = false;
    void Start()
    {
        
    }

    void Update()
    {
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
        playerhp.currentHealth -= damage;
        healthBar.SetHealth(playerhp.currentHealth);
    }
    public void SwitchOut()
    {
        gameObject.SetActive(false);
    }
}
