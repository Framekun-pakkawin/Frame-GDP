using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Attack : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;
    
    void Update()
    {
        if (Input.GetButtonDown("Attack2"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        Instantiate(bulletPrefab,firepoint.position,firepoint.rotation);
    }
}
