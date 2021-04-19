using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2animevent : MonoBehaviour
{
    public GameObject chargeballprefab;
    public Transform chargefirepoint;
    public PlayerMovement player2;
    public void Shoot()
    {
        Instantiate(chargeballprefab, chargefirepoint.position, chargefirepoint.rotation);
    }
    public void DeChargeAttacking()
    {
        player2.ChargeAttacking = false;
    }
}
