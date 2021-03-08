using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Attack : MonoBehaviour
{
    public GameObject HitBox;
    public PlayerMovement playermove;
    void Update()
    {
        if (Input.GetButtonDown("Attack1") && playermove.isAttacking == false)
        {
            playermove.isAttacking = true;
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
    public void Deattacking()
    {
        playermove.isAttacking = false;
    }
    public void Dedamaged()
    {
        playermove.isDamagedanim = false;
    }
}
