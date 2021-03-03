using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperHitbox : MonoBehaviour
{
    public float knockbackX = 50000.0f;
    public float knockbackY = 50000.0f;
    public bool isplayer2 = false;
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (isplayer2 == false) //player1
        {
            if (hitInfo.gameObject.CompareTag("Demon"))
            {
                EnemyStatus enemytoattack = hitInfo.GetComponent<EnemyStatus>();
                enemytoattack.knockback(knockbackX, knockbackY);
                gameObject.SetActive(false);
            }
        }
        else
        {
            if (hitInfo.gameObject.CompareTag("Spirit"))
            {
                EnemyStatus enemytoattack = hitInfo.GetComponent<EnemyStatus>();
                enemytoattack.knockback(knockbackX, knockbackY);
                gameObject.SetActive(false);
            }
        }
    }
}
