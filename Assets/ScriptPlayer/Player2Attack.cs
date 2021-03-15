using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Attack : MonoBehaviour
{
    public Transform firepoint1;
    public Transform firepoint2;
    public Transform firepoint3;
    public Transform firepoint4;
    public Transform firepoint5;
    Transform [] allfirepoint;
    public GameObject bulletPrefab;
    public GameObject gate;
    public float shootingcooldown = 0.2f;
    public PlayerMovement playermove;
    bool isCooldown = false;
    
    void Update()
    {
        Transform[] allfirepoint = { firepoint1, firepoint2, firepoint3, firepoint4, firepoint5 };
        if (playermove.isDamagedanim == false)
        {
            if (Input.GetButtonDown("Attack2") && !isCooldown)
            {
                int x = Random.Range(0,5);
                print(x);
                playermove.isAttacking = true;
                Shoot(allfirepoint[x]);
                gate.SetActive(true);
                StartCoroutine(ShootingCooldown());
            }
        }
    }
    IEnumerator ShootingCooldown()
    {
        isCooldown = true;
        yield return new WaitForSeconds(shootingcooldown);
        isCooldown = false;
    }
    void Shoot(Transform firepoint)
    {
        Instantiate(bulletPrefab,firepoint.position,firepoint.rotation);
    }
}
