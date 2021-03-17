using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSight : MonoBehaviour
{
    public bool istarget1 = true;
    public BossBehavior boss;
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player"))
        {
            if (istarget1)
            {
                boss.target1 = hitInfo.gameObject.transform;
            }
            else
            {
                boss.target2 = hitInfo.gameObject.transform;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player"))
        {
            if (istarget1)
            {
                boss.target1 = hitInfo.gameObject.transform;
            }
            else
            {
                boss.target2 = hitInfo.gameObject.transform;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player"))
        {
            if (istarget1)
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
