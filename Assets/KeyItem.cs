using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour
{
    public static List<string> Alreadycollect = new List<string>();
    public string KeyName = "";
    bool isActived = false;
    void Start()
    {
        if (Alreadycollect.Contains(KeyName))
        {
            gameObject.SetActive(false);
        }
    }
        private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player") && !isActived)
        {
            KeyDoor.key++;
            Alreadycollect.Add(KeyName);
            isActived = true;
            gameObject.SetActive(false);

        }
    }
}
