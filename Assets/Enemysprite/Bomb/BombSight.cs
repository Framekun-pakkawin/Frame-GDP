using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSight : MonoBehaviour
{
    public Bombbehavior bomb;
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player"))
        {
            bomb.target = hitInfo.transform;
        }
    }
}
