using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insertattack : MonoBehaviour
{
    public float attacktime = 1.5f;
    public float attackdelay = 4.0f;
    public GameObject fireball;
    public Insertbehavior Insert;
    bool Attacking = false;
    void Start()
    {
        
    }
    void Update()
    {
        if (Insert.sightBehavior.targetPlayerToChase != null)
        {
            Vector3 targetPosition = Insert.sightBehavior.targetPlayerToChase.transform.position;
            Vector3 currentPosition = gameObject.transform.position;
            if (Mathf.Abs(currentPosition.x - targetPosition.x) <= Insert.distanceforplayer)
            {
                Attack();
            }
        }
    }
    public void Attack()
    {
        StartCoroutine(Attackdelay());
    }
    IEnumerator Attackdelay()
    {
        if (!Attacking)
        {
            Attacking = true;
            Insert.isAttacking = true;
            fireball.SetActive(true);
            yield return new WaitForSeconds(attacktime);
            fireball.SetActive(false);
            Insert.isAttacking = false;
            yield return new WaitForSeconds(attackdelay);
            Attacking = false;
        }
    }
}
