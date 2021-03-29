using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAttack : MonoBehaviour
{
    public GameObject Kaboom;
    public EnemyStatus enemystat;
    Animator anim;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    public void AttackAnim()
    {
        anim.Play("BombAttack");
    }
    public void Attack()
    {
        Instantiate(Kaboom, gameObject.transform.position, gameObject.transform.rotation);
        enemystat.Enemyhp = 0;
        gameObject.SetActive(false);
    }
}
