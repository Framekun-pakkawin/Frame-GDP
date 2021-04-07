using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Sign : MonoBehaviour
{
    public Boss2Behavior boss2;
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player"))
        {
            boss2.target = hitInfo.gameObject.transform;
        }
    }
    private void OnTriggerStay2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player"))
        {
            boss2.target = hitInfo.gameObject.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player"))
        {
            boss2.target = null;
        }
    }
}
