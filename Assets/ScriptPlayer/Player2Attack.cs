using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Attack : MonoBehaviour
{
    public Transform firepoint1;
    public Transform firepoint2;
    public Transform firepoint3;
    Transform [] allfirepoint;
    public GameObject bulletPrefab;
    public GameObject gate;
    public float shootingcooldown = 0.2f;
    public PlayerMovement playermove;
    bool isCooldown = false;

    [HideInInspector]public float charge = 0.0f;
    public float maxcharge = 3.0f;
    public bool isClick = false;
    void Update()
    {
        Transform[] allfirepoint = { firepoint1, firepoint2, firepoint3};
        if (playermove.isDamagedanim == false)
        {
            if (Input.GetButtonDown("Attack2") && !isCooldown)
            {
                int x = Random.Range(0,3);
                playermove.isAttacking = true;
                Shoot(allfirepoint[x]);
                gate.SetActive(true);
                StartCoroutine(ShootingCooldown());
            }
        }
        if (Input.GetButtonDown("Attack2"))
        {
            isClick = true;
        }
        if (Input.GetButtonUp("Attack2"))
        {
            isClick = false;
        }
        if (isClick)
        {
            charge += 1 / maxcharge * Time.deltaTime;
            if (charge >= 1)
            {
                charge = 1;
            }
        }
        else if (!isClick && charge >= 1)
        {
            playermove.ChargeAttacking = true;
            charge = 0.0f;
        }
        else
        {
            charge = 0.0f;
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
