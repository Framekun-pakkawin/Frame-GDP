using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyTextchange : MonoBehaviour
{
    public Text currkey;
    void Update()
    {
        currkey.text = KeyDoor.key.ToString();
    }
}
