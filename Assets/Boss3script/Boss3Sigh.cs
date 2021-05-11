using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Sigh : MonoBehaviour
{
    public Boss3Behavior boss;
    public int whichtarget;
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player"))
        {
            if (whichtarget == 1)
            {
                boss.target1 = hitInfo.transform;
            }
            else
            {
                boss.target2 = hitInfo.transform;
            }
            if (boss.maintarget == null)
            {
                boss.maintarget = hitInfo.transform;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player"))
        {
            if (whichtarget == 1)
            {
                boss.target1 = null;
            }
            else
            {
                boss.target2 = null;
            }
        }
    }
}
