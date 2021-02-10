using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    public HealthBar healthBar;
    public CharacterSwitch characterswitch;
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
    }
    void FixedUpdate()
    {
        if (characterswitch.IsControling == true)
        {
            TakeDamage(1);
        }
        else if (characterswitch.IsControling == false)
        {
            TakeDamage(-2);
        }
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
