using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Attack : MonoBehaviour
{
    public GameObject Attack1Hitbox;
    public GameObject Attack2Hitbox;
    public GameObject boss3Object;
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

    }
    public void BallSummoning()
    {

    }
}
