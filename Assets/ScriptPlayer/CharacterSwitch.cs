using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitch : MonoBehaviour
{
    public bool IsControling = true;
    public PlayerMovement player;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (IsControling == true)
            {
                IsControling = false;
                player.SwitchOut();
            }
            else
            {
                IsControling = true;
            }
        }
    }
    void FixedUpdate()
    {
        if (IsControling == true)
        {
            player.TakeDamage(1);
        }
        else if (IsControling == false)
        {
            player.TakeDamage(-2);
        }
    }
}
