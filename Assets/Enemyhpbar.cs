using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyhpbar : MonoBehaviour
{
    public GameObject enemy;
    EnemyStatus enemystat;
    public Transform hpfill;
    public float offsetY = 5.0f;
    float SizeX;
    public float enmyhp;
    void Start()
    {
        enemystat = enemy.GetComponent<EnemyStatus>();
        SizeX = hpfill.localScale.x;
    }

    void Update()
    {
        hpfill.localScale = new Vector3(SizeX*enemystat.Enemyhp/enemystat.EnemyMaxHp,
                                        hpfill.localScale.y, hpfill.localScale.z);
        enmyhp = enemystat.Enemyhp;
        gameObject.transform.position = new Vector3(enemy.transform.position.x, 
                                                    enemy.transform.position.y - offsetY, enemy.transform.position.z);
        if (enemystat.Enemyhp == 0)
        {
            gameObject.SetActive(false);
        }
    }
}
