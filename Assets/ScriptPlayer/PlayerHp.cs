using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHp : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    public HealthBar healthBar;
    public CharacterSwitch characterswitch;
    public GameObject player;
    public GameObject Deathmenu;
    bool immortal = false;
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
            characterswitch.IsControling = false;
            player.SetActive(false);
            Deathmenu.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (!immortal)
            {
                immortal = true;
            }
            else
            {
                immortal = false;
            }
        }
        if (immortal)
        {
            currentHealth = maxHealth;
        }
    }
    void FixedUpdate()
    {
        if (characterswitch.IsControling == true)
        {
            TakeDamage(2);
        }
        else if (characterswitch.IsControling == false)
        {
            TakeDamage(-3);
        }
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
