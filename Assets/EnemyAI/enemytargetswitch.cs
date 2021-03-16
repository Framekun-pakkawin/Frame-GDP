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
    void Start()
    {
        bean = gameObject.GetComponent<BeanPatrol>();
        spirit = gameObject.GetComponent<Spirit_Behavior>();
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

            }
        }
    }
}
