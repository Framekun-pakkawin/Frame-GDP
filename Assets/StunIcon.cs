using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunIcon : MonoBehaviour
{
    public GameObject stunicon;
    public PlayerMovement player1;
    public PlayerMovement player2;
    public SwitchCenter switchcenter;
    PlayerMovement currplayer;
    
    void Update()
    {
        if (switchcenter.isplayer1)
        {
            currplayer = player1;
        }
        else
        {
            currplayer = player2;
        }
        if (currplayer.isDamagedanim)
        {
            stunicon.SetActive(true);
        }
        else
        {
            stunicon.SetActive(false);
        }
    }
}
