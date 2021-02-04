using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitch : MonoBehaviour
{
    public bool IsControling = true;
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
            }
            else
            {
                IsControling = true;
            }
        }
        
    }
}
