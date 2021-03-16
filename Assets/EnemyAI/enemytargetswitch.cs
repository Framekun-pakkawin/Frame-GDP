using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemytargetswitch : MonoBehaviour
{
    public SwitchCenter switchcenter;
    public Transform player1;
    public Transform player2;
    public string EnemyName = "xxx";

    BeanPatrol bean;
    Spirit_Behavior spirit;
    SpikeyBehavior spike;
    Bombbehavior bomb;
    void Start()
    {
        bean = gameObject.GetComponent<BeanPatrol>();
        spirit = gameObject.GetComponent<Spirit_Behavior>();
        spike = gameObject.GetComponent<SpikeyBehavior>();
        bomb = gameObject.GetComponent<Bombbehavior>();
    }

    void Update()
    {
        if (switchcenter.isplayer1 == true)
        {
            if (EnemyName == "Bean")
            {
                bean.target = player1;
            }
            else if (EnemyName == "Spirit")
            {
                spirit.target = player1;
            }
            else if (EnemyName == "Spikey")
            {
                if (spike.target != null)
                {
                    spike.target = player1;
                }
            }
            else if (EnemyName == "Bomb")
            {
                if (bomb.target != null)
                {
                    bomb.target = player1;
                }
            }
        }
        else
        {
            if (EnemyName == "Bean")
            {
                bean.target = player2;
            }
            else if (EnemyName == "Spirit")
            {
                spirit.target = player2;
            }
            else if (EnemyName == "Spikey")
            {
                if (spike.target != null)
                {
                    spike.target = player2;
                }
            }
            else if (EnemyName == "Bomb")
            {
                if (bomb.target != null)
                {
                    bomb.target = player2;
                }
            }
        }
    }
}
