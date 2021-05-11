using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3BallBeamHitBox : MonoBehaviour
{
    public float damage = 300.0f;
    public float knockbackX = 1000.0f;
    public float knockbackY = 400.0f;
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player") == true)
        {
            PlayerMovement player = hitInfo.GetComponent<PlayerMovement>();
            if (gameObject.transform.position.x >= hitInfo.gameObject.transform.position.x)
            {
                player.knockbackright = false;
            }
            else
            {
                player.knockbackright = true;
            }
            player.knockbackwithdamage(damage, knockbackX, knockbackY);
        }
    }
}
