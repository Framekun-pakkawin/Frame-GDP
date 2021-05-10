using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Attack : MonoBehaviour
{
    public GameObject Attack1Hitbox;
    public GameObject Attack2Hitbox;
    public GameObject boss3Object;
    public GameObject bullettosummon;
    public GameObject bullettopcheck;
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
}
