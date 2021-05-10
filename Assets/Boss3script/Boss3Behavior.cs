using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Behavior : MonoBehaviour
{
    public Animator anim;
    public Transform target1 = null;
    public Transform target2 = null;
    public float WaitingDelay = 1.0f;
    public float WarningDelay = 1.0f;
    public float Delay = 3.0f;
    public bool isAttacking = false;
    public bool isWaiting = false;
    [HideInInspector]public bool Foundplayer = false;
    int []formatkrate = new int[100];
    int closeatk, middleatk, faratk1,faratk2;
    string CurrentState = "xxx";
    string IDEAL = "Idel";
    string ATTACK1 = "Attack01";
    string ATTACK2 = "Attack2";
    string ATTACK3 = "Attack3";
    string ATTACK4 = "Attack4";
    string ATTACK5 = "Attack5";
    void Start()
    {
        formatkrate = new int[100];
    }

    void Update()
    {
        if (!Foundplayer)
        {
            Ideal();
        }
        else
        {
            Attack();
        }
    }
    void Ideal()
    {
        ChargeRandomrate();
    }
    void ChargeRandomrate()
    {
        if (target1 != null)
        {
            closeatk = 55;
            middleatk = 25;
            faratk1 = 10;
            faratk2 = 10;
        }
        else if (target2 != null)
        {
            closeatk = 0;
            middleatk = 50;
            faratk1 = 25;
            faratk2 = 25;
        }
        else
        {
            closeatk = 0;
            middleatk = 0;
            faratk1 = 50;
            faratk2 = 50;
        }
        for (int i=0;i<100;i++)
        {
            if (i < closeatk)
            {
                formatkrate[i] = 1;
            }
            else if (i < closeatk + middleatk)
            {
                formatkrate[i] = 2;
            }
            else if (i < closeatk + middleatk + faratk1)
            {
                formatkrate[i] = 3;
            }
            else
            {
                formatkrate[i] = 4;
            }
        }
    }
    void Attack()
    {
        if (!isAttacking && !isWaiting)
        {
            int x = Random.Range(0, 100);//0-99
            //attack
            Attackform(formatkrate[x]);
        }
    }
    void Attackform(int form)
    {
        if (form == 1)
        { 
            
        }
        else if (form == 2)
        {

        }
        else if (form == 3)
        {

        }
        else if (form == 4)
        {

        }
    }
    public void ChangeAnimationState(string NewState)
    {
        if (CurrentState != NewState)
        {
            anim.Play(NewState);

            CurrentState = NewState;
        }
    }
}
