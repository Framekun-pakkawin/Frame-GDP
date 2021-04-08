using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    public int keyneed = 3;
    public int key = 0;
    private void OnCollisionEnter2D(Collision2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player"))
        {
            if (key >= keyneed)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
