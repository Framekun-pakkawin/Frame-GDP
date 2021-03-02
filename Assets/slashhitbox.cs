using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slashhitbox : MonoBehaviour
{
    public float slashdamage = 10.0f;
    float knockbackX = 750.0f;
    float knockbackY = 300.0f;
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Demon"))
        {
            EnemyStatus enemytoattack = hitInfo.GetComponent<EnemyStatus>();
            enemytoattack.TakeDamage(slashdamage);
            enemytoattack.knockback(knockbackX, knockbackY);
            gameObject.SetActive(false);
        }
    }

}
