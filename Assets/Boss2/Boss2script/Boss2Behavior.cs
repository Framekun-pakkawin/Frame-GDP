using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Behavior : MonoBehaviour
{
    [HideInInspector] public bool isDemon = false;
    public Animator anim;
    public Transform target = null;
    public GameObject Aurawarningred;
    public GameObject Aurawarningblue;
    public float Delay = 3.0f;
    public bool isAttacking = false;
    bool CurrAtkBlue = false;
    string CurrentState = "xxx";
    string IDEAL = "boss2Idel";
    string BluetoRed = "boss2bluetored";
    string RedtoBlue = "boss2redtoblue";
    string RisingUp = "boss2risingup";
    string FallingDown = "boss2fallingdown";
    string BlueAtk = "boss2blueatk";

    void Update()
    {
        ChangingType();
        if (target == null)
        {
            Ideal();
        }
        else
        {
            Attack();
        }
    }
    void ChangingType()
    {
        if (isDemon)
        {
            gameObject.tag = "Demon";
        }
        else
        {
            gameObject.tag = "Spirit";
        }
    }   
    void Ideal()
    {

    }
    void Attack()
    {
        if (!isAttacking)
        {
            if (CurrAtkBlue)
            {
                StartCoroutine(BlueAttacking());
                CurrAtkBlue = false;
            }
            else
            {
                StartCoroutine(RedAttacking());
                CurrAtkBlue = true;
            }
        }
    }
    IEnumerator BlueAttacking()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            ChangeAnimationState(BlueAtk);
            yield return new WaitForSeconds(Delay);
        }
    }
    IEnumerator RedAttacking()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            ChangeAnimationState(BluetoRed);
            yield return new WaitForSeconds(Delay);
        }
    }
    public void PlayAnimFallingDown()
    {
        ChangeAnimationState(FallingDown);
    }
    public void PlayAnimRedtoBlue()
    {
        ChangeAnimationState(RedtoBlue);
    }
    public void PlayAnimRisingUp()
    {
        ChangeAnimationState(RisingUp);
    }
    public void PlayAnimIdeal()
    {
        ChangeAnimationState(IDEAL);
    }
    public void falseisAttacking()
    {
        isAttacking = false;
    }
    public void Changinghitbox()
    { 
        
    }
    public void TypeChange()
    {
        if (isDemon)
        {
            isDemon = false;
        }
        else
        {
            isDemon = true;
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
