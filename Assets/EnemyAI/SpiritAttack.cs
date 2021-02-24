using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritAttack : MonoBehaviour
{
    public float enemydamage = 50.0f;
    float knockbackX = 500.0f;
    float knockbackY = 200.0f;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player"))
        {
            PlayerMovement player = hitInfo.gameObject.GetComponent<PlayerMovement>();
            player.TakeDamage(enemydamage);
            if (gameObject.transform.position.x >= hitInfo.gameObject.transform.position.x)
            {
                player.knockbackright = false;
            }
            else
            {
                player.knockbackright = true;
            }
            player.knockback(knockbackX, knockbackY);
        }
    }

}
