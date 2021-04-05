using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStatus : MonoBehaviour
{
    public EnemyStatus demonhurtbox;
    public EnemyStatus spirithurtbox;
    public GameObject wall;
    BossBehavior boss;

    public float EnemyMaxHpSpirit = 200.0f;
    [HideInInspector]public float EnemyhpSpirit = 200.0f;
    public float EnemyMaxHpDemon = 200.0f;
    [HideInInspector]public float EnemyhpDemon = 200.0f;

    void Start()
    {
        boss = gameObject.GetComponent<BossBehavior>();
        spirithurtbox.EnemyMaxHp = EnemyMaxHpSpirit;
        spirithurtbox.Enemyhp = EnemyMaxHpSpirit;
        demonhurtbox.EnemyMaxHp = EnemyMaxHpDemon;
        demonhurtbox.Enemyhp = EnemyMaxHpDemon;
    }

    void Update()
    {
        if (!boss.isAwakening)
        {
            spirithurtbox.EnemyMaxHp = EnemyMaxHpSpirit;
            spirithurtbox.Enemyhp = EnemyMaxHpSpirit;
            demonhurtbox.EnemyMaxHp = EnemyMaxHpDemon;
            demonhurtbox.Enemyhp = EnemyMaxHpDemon;
        }
        else
        {
            EnemyhpSpirit = spirithurtbox.Enemyhp;
            EnemyhpDemon = demonhurtbox.Enemyhp;
        }
        if (EnemyhpDemon == 0 && EnemyhpSpirit == 0)
        {
            wall.SetActive(false);
            boss.DeadAnimPlay();
        }
    }
    
}
