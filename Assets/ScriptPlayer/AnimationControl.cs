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
    string PLAYER_AIRATTACKRIGHT = "spin_attack";
    string PLAYER_AIRATTACKLEFT = "spin_attack";
    string PLAYER_CHARGEATTACKRIGHT = "Charge_attack";
    string PLAYER_CHARGEATTACKLEFT = "Charge_attack";
    string PLAYER_DAMAGERIGHT = "Damage_front";
    string PLAYER_DAMAGELEFT = "Damage_back";
    string PLAYER_JUMPRISERIGHT = "Jumprising_forward_c1";
    string PLAYER_JUMPRISELEFT = "Jumprising_backward_c1";
    string PLAYER_JUMPFALLRIGHT = "Jumpfall_forward_c1";
    string PLAYER_JUMPFALLLEFT = "Jumpfall_backward_c1";


    ////////////////////////////////

    //ใส่anim ตัวผู้ชาย//

    string PLAYER_IDEALRIGHT2 = "Ideal";
    string PLAYER_IDEALLEFT2 = "Ideal_Back";
    string PLAYER_RUNRIGHT2 = "Runforward";
    string PLAYER_RUNLEFT2 = "RunBackward";
    string PLAYER_ATTACKRIGHT2 = "Attack";
    string PLAYER_ATTACKLEFT2 = "Attack_Back";
    string PLAYER_AIRATTACKRIGHT2 = "Attack";
    string PLAYER_AIRATTACKLEFT2 = "Attack_Back";
    string PLAYER_CHARGEATTACKRIGHT2 = "Charge02_attack";
    string PLAYER_CHARGEATTACKLEFT2 = "Charge02_attack_back";
    string PLAYER_DAMAGERIGHT2 = "Damage";
    string PLAYER_DAMAGELEFT2 = "Damage_back";
    string PLAYER_JUMPRISERIGHT2 = "Jump_forward_c2";
    string PLAYER_JUMPRISELEFT2 = "Jump_backward_c2";
    string PLAYER_JUMPFALLRIGHT2 = "Jump_forward_c2";
    string PLAYER_JUMPFALLLEFT2 = "Jump_backward_c2";


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
            PLAYER_AIRATTACKRIGHT = PLAYER_AIRATTACKRIGHT2;
            PLAYER_AIRATTACKLEFT = PLAYER_AIRATTACKLEFT2;
            PLAYER_CHARGEATTACKRIGHT = PLAYER_CHARGEATTACKRIGHT2;
            PLAYER_CHARGEATTACKLEFT = PLAYER_CHARGEATTACKLEFT2;
            PLAYER_DAMAGERIGHT = PLAYER_DAMAGERIGHT2;
            PLAYER_DAMAGELEFT = PLAYER_DAMAGELEFT2;
            PLAYER_JUMPRISERIGHT = PLAYER_JUMPRISERIGHT2;
            PLAYER_JUMPRISELEFT = PLAYER_JUMPRISELEFT2;
            PLAYER_JUMPFALLRIGHT = PLAYER_JUMPFALLRIGHT2;
            PLAYER_JUMPFALLLEFT = PLAYER_JUMPFALLLEFT2;
        }

        ////////////////////////////////
    }

    void Update()
    {
        if (player.isFacingright)
        {
            if (!player.ChargeAttacking)
            {
                if (player.isDamagedanim)
                {
                    ChangeAnimationState(PLAYER_DAMAGERIGHT);
                }
                else
                {
                    if (!player.isGround)
                    {
                        if (!player.isAttacking)
                        {
                            if (!player.isFalling)
                            {
                                ChangeAnimationState(PLAYER_JUMPRISERIGHT);
                            }
                            else
                            {
                                ChangeAnimationState(PLAYER_JUMPFALLRIGHT);
                            }
                        }
                        else
                        {
                            ChangeAnimationState(PLAYER_AIRATTACKRIGHT);
                        }
                        
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
            }
            else
            {
                ChangeAnimationState(PLAYER_CHARGEATTACKRIGHT);
            }
        }
        if (!player.isFacingright)
        {
            if (!player.ChargeAttacking)
            {
                if (player.isDamagedanim)
                {
                    ChangeAnimationState(PLAYER_DAMAGELEFT);
                }
                else
                {
                    if (!player.isGround)
                    {
                        if (!player.isAttacking)
                        {
                            if (!player.isFalling)
                            {
                                ChangeAnimationState(PLAYER_JUMPRISELEFT);
                            }
                            else
                            {
                                ChangeAnimationState(PLAYER_JUMPFALLLEFT);
                            }
                        }
                        else
                        {
                            ChangeAnimationState(PLAYER_AIRATTACKLEFT);
                        }
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
            else
            {
                ChangeAnimationState(PLAYER_CHARGEATTACKLEFT);
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
