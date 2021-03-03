using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    private string CurrentState;
    public Animator animator;
    PlayerMovement player;
    public bool isplayer2 = false;

    float attackDelay = 0.3f;

    //ใส่anim ตัวผู้หญิง//

    string PLAYER_IDEALRIGHT = "Ideal";
    string PLAYER_IDEALLEFT = "Idealback";
    string PLAYER_RUNRIGHT = "Run_Forward";
    string PLAYER_RUNLEFT = "Run_backWard";
    string PLAYER_ATTACKRIGHT = "Attack1";
    string PLAYER_ATTACKLEFT = "Attack1";
    string PLAYER_DAMAGERIGHT = "Damage_front";
    string PLAYER_DAMAGELEFT = "Damage_back";
    string PLAYER_JUMPRIGHT = "Jump_forward_c1";
    string PLAYER_JUMPLEFT = "Jump_backward_c1";


    ////////////////////////////////

    //ใส่anim ตัวผู้ชาย//

    string PLAYER_IDEALRIGHT2 = "Ideal";
    string PLAYER_IDEALLEFT2 = "Ideal_Back";
    string PLAYER_RUNRIGHT2 = "Runforward";
    string PLAYER_RUNLEFT2 = "RunBackward";
    string PLAYER_ATTACKRIGHT2 = "Attack";
    string PLAYER_ATTACKLEFT2 = "Attack_Back";
    string PLAYER_DAMAGERIGHT2 = "Damage";
    string PLAYER_DAMAGELEFT2 = "Damage_back";
    string PLAYER_JUMPRIGHT2 = "Jump_forward_c2";
    string PLAYER_JUMPLEFT2 = "Jump_backward_c2";


    ////////////////////////////////

    void Start()
    {
        player = gameObject.GetComponent<PlayerMovement>();
        //ใส่anim ผู้ชาย// 2 = ผู้ชาย
        if (isplayer2 == true)
        {
            PLAYER_IDEALRIGHT = PLAYER_IDEALRIGHT2;
            PLAYER_IDEALLEFT = PLAYER_IDEALLEFT2;
            PLAYER_RUNRIGHT = PLAYER_RUNRIGHT2;
            PLAYER_RUNLEFT = PLAYER_RUNLEFT2;
            PLAYER_ATTACKRIGHT = PLAYER_ATTACKRIGHT2;
            PLAYER_ATTACKLEFT = PLAYER_ATTACKLEFT2;
            PLAYER_DAMAGERIGHT = PLAYER_DAMAGERIGHT2;
            PLAYER_DAMAGELEFT = PLAYER_DAMAGELEFT2;
            PLAYER_JUMPRIGHT = PLAYER_JUMPRIGHT2;
            PLAYER_JUMPLEFT = PLAYER_JUMPLEFT2;
        }

        ////////////////////////////////
    }

    void Update()
    {
        if (player.isFacingright)
        {
            if (!player.isGround)
            {
                ChangeAnimationState(PLAYER_JUMPRIGHT);
            }
            else if (player.isGround)
            {
                if (!player.isAttacking)
                {
                    if (player.isMoving)
                    {
                        ChangeAnimationState(PLAYER_RUNRIGHT);
                    }
                    else if (!player.isMoving)
                    {
                        ChangeAnimationState(PLAYER_IDEALRIGHT);
                    }
                }
                else
                {
                    ChangeAnimationState(PLAYER_ATTACKRIGHT);
                }
            }
        }
        if (!player.isFacingright)
        {
            if (!player.isGround)
            {
                ChangeAnimationState(PLAYER_JUMPLEFT);
            }
            else if (player.isGround)
            {
                if (!player.isAttacking)
                {
                    if (player.isMoving)
                    {
                        ChangeAnimationState(PLAYER_RUNLEFT);
                    }
                    else if (!player.isMoving)
                    {
                        ChangeAnimationState(PLAYER_IDEALLEFT);
                    }
                }
                else
                {
                    ChangeAnimationState(PLAYER_ATTACKLEFT);
                }
            }
        }
    }
    public void ChangeAnimationState(string NewState)
    {
        if (CurrentState != NewState)
        {
            animator.Play(NewState);

            CurrentState = NewState;
        }
    }
}
