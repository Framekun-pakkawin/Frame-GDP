using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemytargetswitch : MonoBehaviour
{
    public SwitchCenter switchcenter;
    public Transform player1;
    public Transform player2;
    public bool isBean = false;
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
            if (isBean == true)
            {
                bean.target = player1;
            }
            else 
            {
                spirit.target = player1;
            }
        }
        else
        {
            if (isBean == true)
            {
                bean.target = player2;
            }
            else
            {
                spirit.target = player2;
            }
        }
    }
}
