using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpointtrigger : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player"))
        {
            PlayerMovement.currentcheckpoint = 1;
        }
    }
}
