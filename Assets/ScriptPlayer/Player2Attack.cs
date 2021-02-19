using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Attack : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;
    public PlayerMovement playermove;
    
    void Update()
    {
        if (Input.GetButtonDown("Attack2"))
        {
            playermove.ChangeAnimationState("Attack");
            Shoot();
        }
    }
    void Shoot()
    {
        Instantiate(bulletPrefab,firepoint.position,firepoint.rotation);
    }
}
