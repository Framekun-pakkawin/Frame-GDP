using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beanattack : MonoBehaviour
{
    public float enemydamage = 5.0f;
    bool ishitting = false;
    Rigidbody2D rb;
    EnemyStatus enemyStatus = null;
    float knowbackX = 1000.0f;
    float knowbackY = 400.0f;
    void Start()
    {
        enemyStatus = gameObject.GetComponent<EnemyStatus>();
    }

    
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player") && ishitting == false)
        {
            PlayerMovement player = hitInfo.gameObject.GetComponent<PlayerMovement>();
            player.TakeDamage(enemydamage);
            if (gameObject.transform.position.x >= hitInfo.gameObject.transform.position.x)
            {
                player.knockbackright = false;
                enemyStatus.knockbackright = true;
            }
            else
            {
                player.knockbackright = true;
                enemyStatus.knockbackright = false;
            }
            enemyStatus.knockback(knowbackX, knowbackY);
            player.knockback(knowbackX/2, knowbackY/2);
            ishitting = true;
        }
    }
    private void OnCollisionExit2D(Collision2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player"))
        {
            ishitting = false;
        }
    }
}
