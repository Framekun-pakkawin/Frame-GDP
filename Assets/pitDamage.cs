using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pitDamage : MonoBehaviour
{
    public float Damage = 200.0f;
    public GameObject warpbackpoint;
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player"))
        {
            PlayerMovement player = hitInfo.GetComponent<PlayerMovement>();
            player.TakeDamage(Damage);
            player.transform.position = warpbackpoint.transform.position;
        }
    }
}
