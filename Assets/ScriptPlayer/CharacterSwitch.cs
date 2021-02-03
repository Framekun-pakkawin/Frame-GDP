using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitch : MonoBehaviour
{
    public bool ControlingP1 = true;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (ControlingP1 == true)
            {
                ControlingP1 = false;
            }
            else
            {
                ControlingP1 = true;
            }
        }
        
    }
}
