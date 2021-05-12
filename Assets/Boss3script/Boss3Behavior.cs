using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Behavior : MonoBehaviour
{
    public Animator anim;
    [HideInInspector] public Transform maintarget = null;
    [HideInInspector] public Transform target1 = null;
    [HideInInspector] public Transform target2 = null;
    public float WaitingDelay = 2.0f;
    public float WarningDelay = 1.0f;
    public float Delay = 3.0f;
    public bool isAttacking = false;
    public bool isWaiting = false;
    EnemyStatus status;
    int[] formatkrate = new int[100];
    int closeatk, middleatk, faratk1, faratk2;
    bool once = false;
    bool alreadyhalfhp = false;
    bool alreadylowhp = false;
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
        status = GetComponent<EnemyStatus>();
    }

    void Update()
    {
        if (maintarget == null)
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

    }
    void ChangeFacing()
    {
        if (maintarget != null)
        {
            if (gameObject.transform.position.x >= maintarget.position.x)
            {
                status.knockbackright = true;
                gameObject.transform.eulerAngles = new Vector3(0,0,0);
                //gameObject.transform.localScale = new Vector3(Mathf.Abs(gameObject.transform.localScale.x), gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            }
            else
            {
                status.knockbackright = false;
                gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
                //gameObject.transform.localScale = new Vector3(-Mathf.Abs(gameObject.transform.localScale.x), gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            }

        }
    }
    void ChargeRandomrate()
    {
        if (target1 != null)
        {
            closeatk = 40;
            middleatk = 30;
            faratk1 = 15;
            faratk2 = 15;
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
        for (int i = 0; i < 100; i++)
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
        ChangeFacing();
        ChargeRandomrate();
        if (!isAttacking && !isWaiting)
        {
            isAttacking = true;
            int x = Random.Range(0, 100);//0-99
            //attack
            Attackform(formatkrate[x]);
        }
        else if (!isAttacking && isWaiting)
        {
            ChangeAnimationState(IDEAL);
        }
        if (status.Enemyhp <= status.EnemyMaxHp/2.0f && !alreadyhalfhp)
        {
            isAttacking = true;
            ChangeAnimationState(ATTACK5);
            alreadyhalfhp = true;
        }
        if (status.Enemyhp <= status.EnemyMaxHp / 4.0f && !alreadylowhp)
        {
            isAttacking = true;
            ChangeAnimationState(ATTACK5);
            alreadylowhp = true;
        }
    }
    void Attackform(int form)
    {
        //ChangeAnimationState(ATTACK1);
        if (form == 1)
        {
            ChangeAnimationState(ATTACK1);
        }
        else if (form == 2)
        {
            ChangeAnimationState(ATTACK2);
        }
        else if (form == 3)
        {
            ChangeAnimationState(ATTACK3);
        }
        else if (form == 4)
        {
            ChangeAnimationState(ATTACK4);
        }
    }
    public void StartDelay()
    {
        StartCoroutine(Waiting());
    }
    public IEnumerator Waiting()
    {
        if (!isWaiting)
        {
            isWaiting = true;
            yield return new WaitForSeconds(WaitingDelay);
            isWaiting = false;
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
