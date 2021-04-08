using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Targetswitch : MonoBehaviour
{
    Boss2Behavior boss2;
    public Transform player1;
    public Transform player2;
    public SwitchCenter switchcenter;
    void Start()
    {
        boss2 = gameObject.GetComponent<Boss2Behavior>();
    }

    void Update()
    {
        if (boss2.target != null)
        {
            if (switchcenter.isplayer1)
            {
                boss2.target = player1;
            }
            else
            {
                boss2.target = player2;
            }
        }
    }
}
