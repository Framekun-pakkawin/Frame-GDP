using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2helpP1 : MonoBehaviour
{
    public GameObject HitBox;
    public PlayerMovement playermove;
    public CharacterSwitch switchplayer;
    void Update()
    {
        if (switchplayer.IsControling == true)
        {
            if (Input.GetButtonDown("Attack2"))
            {
                playermove.isHelped = true;
            }
        }
    }
    public void Active_hitBox()
    {
        HitBox.SetActive(true);
    }

    public void Deactive_hitBox()
    {
        HitBox.SetActive(false);
    }
}
