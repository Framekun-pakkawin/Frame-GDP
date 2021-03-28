using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeyBehavior : MonoBehaviour
{
    public Transform target = null;
    public Spikeyattack spikeyattack;
    public GameObject spikeprefab;
    public float timedelay = 4.0f;
    bool isAttacking = false;
    void Start()
    {

    }


    void Update()
    {
        if (target != null)
        {
            StartCoroutine(AttackingDelay());
        }
    }
    IEnumerator AttackingDelay()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            spikeyattack.PlayAttackAnim();
            yield return new WaitForSeconds(timedelay);
            isAttacking = false;
        }
    }
}
