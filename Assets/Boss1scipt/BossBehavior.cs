using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    private string CurrentState;
    public Animator anim;
    public Transform target1 = null;
    public Transform target2 = null;
    public float awakedelay = 3.0f;
    public float auradelay = 0.8f;
    public float beamdelay = 3.0f;
    public float handdelay = 0.8f;
    public float grabattack = 3.0f;
    public GameObject Aurawarningred;
    public GameObject Aurawarningblue;

    public bool isAwakening = false;
    bool isAttacking = false;
    bool Awaken = false;
    bool isDead = false;

    string IDEAL = "Idel";
    string AWAKE = "Awaken";
    string DEAD = "Dead";
    string HANDATTACK = "Attack";
    string BEAMATTACK = "Final_Attack";

    void Start()
    {
        
    }

    void Update()
    {
        if (!isDead)
        {
            if (target1 != null && target2 == null)
            {
                if (!isAwakening)
                {
                    StartCoroutine(PlayerAwakeAnim());
                }
                else
                {
                    Playerfar();
                }
            }
            else if (target1 != null && target2 != null)
            {
                if (!isAwakening)
                {
                    StartCoroutine(PlayerAwakeAnim());
                }
                else
                {
                    Playerclose();
                }
            }
            else
            {
                Idle();
            }
        }
    }
    void Playerfar()
    {
        if (!isAttacking)
        {
            StartCoroutine(Attacking(1));
        }
    }
    void Idle()
    {
        
    }
    void Playerclose()
    {
        if (!isAttacking)
        {
            int x = Random.Range(0, 2);
            StartCoroutine(Attacking(x));
        }
    }
    IEnumerator Attacking(int form)//0=red 1=blue
    {
        if (!isAttacking)
        {
            isAttacking = true;
            if (form == 0){Instantiate(Aurawarningred, gameObject.transform.position, gameObject.transform.rotation);}
            else{Instantiate(Aurawarningblue, gameObject.transform.position, gameObject.transform.rotation);}
            yield return new WaitForSeconds(auradelay);
            if (form == 0) { Instantiate(Aurawarningred, gameObject.transform.position, gameObject.transform.rotation); }
            else { Instantiate(Aurawarningblue, gameObject.transform.position, gameObject.transform.rotation); }
            yield return new WaitForSeconds(auradelay);
            if (form == 0) { Instantiate(Aurawarningred, gameObject.transform.position, gameObject.transform.rotation); }
            else { Instantiate(Aurawarningblue, gameObject.transform.position, gameObject.transform.rotation); }
            yield return new WaitForSeconds(auradelay);
            if (form == 0) 
            { 
                ChangeAnimationState(HANDATTACK);
                yield return new WaitForSeconds(handdelay);
            }
            else 
            { 
                ChangeAnimationState(BEAMATTACK);
                yield return new WaitForSeconds(beamdelay);
            }
            ChangeAnimationState(IDEAL);
            yield return new WaitForSeconds(grabattack);
            isAttacking = false;
        }
    }
    IEnumerator PlayerAwakeAnim()
    {
        if (!Awaken)
        {
            Awaken = true;
            ChangeAnimationState(AWAKE);
            yield return new WaitForSeconds(awakedelay);
            isAwakening = true;
        }
    }
    public void DeadAnimPlay()
    {
        isDead = true;
        ChangeAnimationState(DEAD);
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
