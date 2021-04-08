using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Behavior : MonoBehaviour
{
    [HideInInspector] public bool isDemon = false;
    public Animator anim;
    public BoxCollider2D bluehurtbox;
    public BoxCollider2D redhurtbox;
    public Transform target = null;
    public GameObject Aurawarningred;
    public GameObject Aurawarningblue;
    public float WaitingDelay = 1.0f;
    public float WarningDelay = 1.0f;
    public float Delay = 3.0f;
    public bool isAttacking = false;
    bool CurrAtkBlue = false;
    bool Waitplayredtoblueanim = false;
    bool finishingdelay = false;
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
        if (Waitplayredtoblueanim)
        {
            if (finishingdelay)
            {
                ChangeAnimationState(RedtoBlue);
                Waitplayredtoblueanim = false;
                finishingdelay = false;
            }
        }
    }
    IEnumerator BlueAttacking()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            Instantiate(Aurawarningblue,gameObject.transform.position,gameObject.transform.rotation);
            yield return new WaitForSeconds(WarningDelay);
            ChangeAnimationState(BlueAtk);
            yield return new WaitForSeconds(Delay);
        }
    }
    IEnumerator RedAttacking()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            yield return new WaitForSeconds(WaitingDelay);
            Instantiate(Aurawarningred, gameObject.transform.position, gameObject.transform.rotation);
            yield return new WaitForSeconds(WarningDelay);
            ChangeAnimationState(BluetoRed);
            yield return new WaitForSeconds(Delay);
        }
    }
    IEnumerator WaitDelayanim()
    {
        if (!finishingdelay)
        {
            yield return new WaitForSeconds(WaitingDelay);
            finishingdelay = true;
        }
    }
    public void PlayAnimFallingDown()
    {
        ChangeAnimationState(FallingDown);
    }
    public void PlayAnimRedtoBlue()
    {
        Waitplayredtoblueanim = true;
        StartCoroutine(WaitDelayanim());
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
        if (bluehurtbox.enabled)
        {
            bluehurtbox.enabled = false;
            redhurtbox.enabled = true;
        }
        else
        {
            redhurtbox.enabled = false;
            bluehurtbox.enabled = true;
        }
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
