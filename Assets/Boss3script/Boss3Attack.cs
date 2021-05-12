using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Attack : MonoBehaviour
{
    public GameObject Attack1Hitbox;
    public GameObject Attack2Hitbox;
    public GameObject Attack3Hitbox;
    public GameObject boss3Object;
    public GameObject bullettosummon;
    public GameObject bullettopcheck;
    public GameObject bullettpoint1;
    public GameObject bullettpoint2;
    public GameObject bullettpoint3;
    public GameObject bullettpoint4;
    public GameObject bullettpoint5;
    public GameObject bullettpoint6;
    public GameObject finalwarppoint;
    public GameObject balltosummon;
    public GameObject ballpoint;
    public int amoungtosummon = 10;
    public float Delayfromeachsword = 0.5f;
    int alreadysummon = 0;
    float wrapdistance = 2.0f;
    Boss3Behavior boss3;
    void Start()
    {
        boss3 = boss3Object.GetComponent<Boss3Behavior>();
    }
    public void ActiveHitBox1()
    {
        Attack1Hitbox.SetActive(true);
    }
    public void DeactiveHitBox1()
    {
        Attack1Hitbox.SetActive(false);
    }
    public void ActiveHitBox2()
    {
        Attack2Hitbox.SetActive(true);
    }
    public void DeactiveHitBox2()
    {
        Attack2Hitbox.SetActive(false);
    }
    public void ActiveHitBox3()
    {
        Attack3Hitbox.SetActive(true);
    }
    public void DeactiveHitBox3()
    {
        Attack3Hitbox.SetActive(false);
    }
    public void FinishAttacking()
    {
        boss3.StartDelay();
        boss3.isAttacking = false;
    }
    public void WraptoPlayer()
    {
        int x = Random.Range(0, 2);
        if (x == 0)
        {
            boss3Object.transform.position = new Vector3(boss3.maintarget.position.x + wrapdistance, boss3.maintarget.position.y, boss3.maintarget.position.z);
        }
        else if (x == 1)
        {
            boss3Object.transform.position = new Vector3(boss3.maintarget.position.x - wrapdistance, boss3.maintarget.position.y, boss3.maintarget.position.z);
        }
    }
    public void RainSword()
    {
        StartCoroutine(SwordSummon());
    }
    IEnumerator SwordSummon()
    {
        for(int i=0;i<amoungtosummon;i++)
        {
            int x = Random.Range(0, 11)-5;//0-10==>> [-5,5]
            Instantiate(bullettosummon, new Vector3(boss3.maintarget.transform.position.x + x, bullettopcheck.transform.position.y, 0), bullettosummon.transform.rotation);
            yield return new WaitForSeconds(Delayfromeachsword);
        }
    }
    public void BallSummoning()
    {
        Instantiate(balltosummon,ballpoint.transform.position,ballpoint.transform.rotation);
    }
    public void FinalSwordSum1()
    {
        Instantiate(bullettosummon, bullettpoint1.transform.position, bullettpoint1.transform.rotation);
        Instantiate(bullettosummon, bullettpoint2.transform.position, bullettpoint2.transform.rotation);
    }
    public void FinalSwordSum2()
    {
        Instantiate(bullettosummon, bullettpoint3.transform.position, bullettpoint3.transform.rotation);
        Instantiate(bullettosummon, bullettpoint4.transform.position, bullettpoint4.transform.rotation);
    }
    public void FinalSwordSum3()
    {
        Instantiate(bullettosummon, bullettpoint5.transform.position, bullettpoint5.transform.rotation);
        Instantiate(bullettosummon, bullettpoint6.transform.position, bullettpoint6.transform.rotation);
    }
    public void FinalWrap()
    {
        boss3Object.transform.position = finalwarppoint.transform.position;
    }
}
