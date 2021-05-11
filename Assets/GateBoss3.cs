using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateBoss3 : MonoBehaviour
{
    public GameObject MagicFx;
    public GameObject Boss3HP;
    public Boss3Behavior boss3;
    bool alreadyhit = false;
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Player") && !alreadyhit)
        {
            MagicFx.SetActive(true);
            Boss3HP.SetActive(true);
            boss3.maintarget = hitInfo.transform;
            alreadyhit = true;
        }
    }
}
