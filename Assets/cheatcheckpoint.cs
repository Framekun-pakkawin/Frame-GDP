using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cheatcheckpoint : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            PlayerMovement.currentcheckpoint = 3;
        }
    }
}
