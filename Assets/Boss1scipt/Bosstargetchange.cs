using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosstargetchange : MonoBehaviour
{
    public SwitchCenter switchcenter;
    public Transform player1;
    public Transform player2;

    BossBehavior boss;
    void Start()
    {
        boss = gameObject.GetComponent<BossBehavior>();
    }

    void Update()
    {
        if (switchcenter.isplayer1 == true)
        {
            if (boss.target1 != null)
            {
                boss.target1 = player1;
            }
            if (boss.target2 != null)
            {
                boss.target2 = player1;
            }
        }
        else
        {
            if (boss.target1 != null)
            {
                boss.target1 = player2;
            }
            if (boss.target2 != null)
            {
                boss.target2 = player2;
            }
        }
    }
}
