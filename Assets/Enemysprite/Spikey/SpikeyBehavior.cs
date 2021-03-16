using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeyBehavior : MonoBehaviour
{
    [HideInInspector] public Transform target = null;
    public GameObject spikeprefab;
    public float timedelay = 2.0f;
    bool isAttacking = false;
    void Start()
    {

    }


    void Update()
    {
        if (target != null)
        {
            Attacking();
        }
    }
    void Attacking()
    {
        //playanim attack
        StartCoroutine(AttackingDelay());
    }
    IEnumerator AttackingDelay()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            Instantiate(spikeprefab, new Vector3(target.position.x,gameObject.transform.position.y,target.position.z),target.rotation);
            yield return new WaitForSeconds(timedelay);
            isAttacking = false;
        }
    }
}
