﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAttack : MonoBehaviour
{
    public GameObject Kaboom;
    EnemyStatus enemystat;
    void Start()
    {
        enemystat = gameObject.GetComponent<EnemyStatus>();
    }
    private void OnCollisionEnter2D(Collision2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player"))
        {
            Attack();
        }
    }

    void Attack()
    {
        Instantiate(Kaboom, gameObject.transform.position, gameObject.transform.rotation);
        enemystat.Enemyhp = 0;
        gameObject.SetActive(false);
    }
}