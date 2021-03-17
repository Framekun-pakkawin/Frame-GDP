using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHpbar : MonoBehaviour
{
    public GameObject boss;
    BossStatus bossstat;
    public bool isDemonHp = true;
    public Transform hpfill;
    public float offsetX = 0.0f;
    public float offsetY = 5.0f;
    float SizeX;
    void Start()
    {
        bossstat = boss.GetComponent<BossStatus>();
        SizeX = hpfill.localScale.x;
    }

    void Update()
    {
        if (isDemonHp)
        {
            hpfill.localScale = new Vector3(SizeX * bossstat.EnemyhpDemon / bossstat.EnemyMaxHpDemon,
                                            hpfill.localScale.y, hpfill.localScale.z);
            if (bossstat.EnemyhpDemon == 0)
            {
                gameObject.SetActive(false);
            }
        }
        else 
        {
            hpfill.localScale = new Vector3(SizeX * bossstat.EnemyhpSpirit / bossstat.EnemyMaxHpSpirit,
                                            hpfill.localScale.y, hpfill.localScale.z);
            if (bossstat.EnemyhpSpirit == 0)
            {
                gameObject.SetActive(false);
            }
        }
        gameObject.transform.position = new Vector3(boss.transform.position.x + offsetX,
                                                    boss.transform.position.y - offsetY, boss.transform.position.z);
        
    }
}
