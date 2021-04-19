﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Attack : MonoBehaviour
{
    public GameObject HitBox;
    public GameObject ChargeHitBox;
    public PlayerMovement playermove;
    [HideInInspector]public float charge = 0.0f;
    public float maxcharge = 3.0f;
    void Update()
    {
        if (Input.GetButtonDown("Attack1") && playermove.isAttacking == false)
        {
            playermove.isAttacking = true;
        }
        if (Input.GetButton("Attack1"))
        {
            charge += 1/maxcharge*Time.deltaTime;
            if (charge >= 1)
            {
                charge = 1;
            }
        }
        else if (Input.GetButtonUp("Attack1") && charge >= 1)
        {
            playermove.ChargeAttacking = true;
            charge = 0.0f;
        }
        else
        {
            charge = 0.0f;
        }
    }
    public void Active_chargehitBox()
    {
        ChargeHitBox.SetActive(true);
    }
    public void Deactive_chargehitBox()
    {
        ChargeHitBox.SetActive(false);
    }
    public void Active_hitBox()
    {
        HitBox.SetActive(true);
    }

    public void Deactive_hitBox()
    {
        HitBox.SetActive(false);
    }
    public void Dechargeattacking()
    {
        playermove.ChargeAttacking = false;
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
