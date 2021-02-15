using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public CharacterSwitch characterswitch;
    float horizontalmove = 0.0f;
    public float runspeed = 3.0f;
    public HealthBar healthBar;
    public PlayerHp playerhp;
    public bool isplayer2 = false;
    bool jump = false;
    public Animator animator;
    private string CurrentState;


    //ใส่anim ตัวผู้หญิง//

    string PLAYER_IDEALRIGHT = "Ideal";
    string PLAYER_IDEALLEFT = "Idealback";
    string PLAYER_RUNRIGHT = "Run_Forward";
    string PLAYER_RUNLEFT = "Run_backWard";
    string PLAYER_ATTACK = "Attack1";
    string PLAYER_DAMAGERIGHT = "Damage_front";
    string PLAYER_DAMAGELEFT = "Damage_back";

    ////////////////////////////////
    
    //ใส่anim ตัวผู้ชาย//

    string PLAYER_IDEALRIGHT2 = "Ideal";
    string PLAYER_IDEALLEFT2 = "Idealback";
    string PLAYER_RUNRIGHT2 = "Run_Foward";
    string PLAYER_RUNLEFT2 = "Run_backWard";
    string PLAYER_ATTACK2 = "Attack1";
    string PLAYER_DAMAGERIGHT2 = "Damage_front";
    string PLAYER_DAMAGELEFT2 = "Damage_back";

    ////////////////////////////////
    
    void Start()
    {
        //ใส่anim ผู้ชาย// 2 = ผู้ชาย
        if (isplayer2 == true)
        {
            PLAYER_IDEALRIGHT = PLAYER_IDEALRIGHT2;
            PLAYER_IDEALLEFT = PLAYER_IDEALLEFT2;
            PLAYER_RUNRIGHT = PLAYER_RUNRIGHT2;
            PLAYER_RUNLEFT = PLAYER_RUNLEFT2;
            PLAYER_ATTACK = PLAYER_ATTACK2;
            PLAYER_DAMAGERIGHT = PLAYER_DAMAGERIGHT2;
            PLAYER_DAMAGELEFT = PLAYER_DAMAGELEFT2;
        }

        ////////////////////////////////
    }

    void Update()
    {
        if (characterswitch.IsControling == true)
        {
            horizontalmove = Input.GetAxisRaw("Horizontal") * runspeed;
            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
            }
        }
        if (horizontalmove > 0)
        {
            ChangeAnimationState(PLAYER_RUNRIGHT);
        }
        else if (horizontalmove < 0)
        {
            ChangeAnimationState(PLAYER_RUNLEFT);
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalmove * Time.deltaTime,false,jump);
        jump = false;
    }
    public void TakeDamage(int damage)
    {
        playerhp.currentHealth -= damage;
        healthBar.SetHealth(playerhp.currentHealth);
    }
    public void SwitchOut()
    {
        gameObject.SetActive(false);
    }
    public void ChangeAnimationState(string NewState) 
    {
        if (CurrentState == NewState) { return; }

        animator.Play(NewState);

        CurrentState = NewState;
    }
}
