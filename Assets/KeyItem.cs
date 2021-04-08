using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour
{
    public KeyDoor doortoopen;
    bool isActived = false;
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player") && !isActived)
        {
            doortoopen.key++;
            isActived = true;
            gameObject.SetActive(false);

        }
    }
}
