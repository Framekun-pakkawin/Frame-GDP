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

    //Animation State Name Player1//

    string PLAYER_IDEALRIGHT = "Ideal";
    string PLAYER_IDEALLEFT = "Idealback";
    string PLAYER_RUNRIGHT = "Run_Foward";
    string PLAYER_RUNLEFT = "Run_backWard";
    string PLAYER_ATTACK = "Attack1";
    string PLAYER_DAMAGERIGHT = "Damage_front";
    string PLAYER_DAMAGELEFT = "Damage_back";

    ////////////////////////////////
    
    void Start()
    {
        //Animation State Name Player2//
        if (isplayer2 == true)
        {
            PLAYER_IDEALRIGHT = "Ideal";
            PLAYER_IDEALLEFT = "Idealback";
            PLAYER_RUNRIGHT = "Run_Foward";
            PLAYER_RUNLEFT = "Run_backWard";
            PLAYER_ATTACK = "Attack1";
            PLAYER_DAMAGERIGHT = "Damage_front";
            PLAYER_DAMAGELEFT = "Damage_back";
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
