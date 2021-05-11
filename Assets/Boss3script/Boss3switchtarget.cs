using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3switchtarget : MonoBehaviour
{
    public SwitchCenter switchcenter;
    public Transform player1;
    public Transform player2;
    Boss3Behavior boss3;

    void Start()
    {
        boss3 = GetComponent<Boss3Behavior>();
    }
    void Update()
    {
        if (boss3.maintarget != null)
        {
            if (switchcenter.isplayer1 == true)
            {
                boss3.maintarget = player1;
            }
            else
            {
                boss3.maintarget = player2;
            }
        }
    }
}
