using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Attack : MonoBehaviour
{
    public GameObject HitBox;
    public GameObject ChargeHitBox;
    public GameObject AirHitBox;
    public PlayerMovement playermove;
    [HideInInspector]public float charge = 0.0f;
    public float maxcharge = 3.0f;

    SwitchCenter switchCenter;
    public string soundname = "xxx";
    AudioManager audiomanager;

    void Start()
    {
        GameObject AM = GameObject.Find("AudioManager");
        audiomanager = AM.GetComponent<AudioManager>();
        GameObject SC = GameObject.Find("switchcenter");
        switchCenter = SC.GetComponent<SwitchCenter>();
    }
    void Update()
    {
        if (playermove.isGround)
        {
            AirHitBox.SetActive(false);
        }
        if (Input.GetButtonDown("Attack1") && playermove.isAttacking == false && playermove.isGround)
        {
            playermove.isAttacking = true;
        }
        else if (Input.GetButtonDown("Attack1") && playermove.isAirAttacking == false && !playermove.isGround)
        {
            playermove.isAirAttacking = true;
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
    public void Active_airhitBox()
    {
        if (switchCenter.isplayer1)
        {
            audiomanager.Play(soundname);
        }
        AirHitBox.SetActive(true);
    }
    public void Deactive_airhitBox()
    {
        AirHitBox.SetActive(false);
    }
    public void Active_chargehitBox()
    {
        if (switchCenter.isplayer1)
        {
            audiomanager.Play(soundname);
        }
        ChargeHitBox.SetActive(true);
    }
    public void Deactive_chargehitBox()
    {
        ChargeHitBox.SetActive(false);
    }
    public void Active_hitBox()
    {
        if (switchCenter.isplayer1)
        {
            audiomanager.Play(soundname);
        }
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
    public void Deairattacking()
    {
        playermove.isAirAttacking = false;
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
