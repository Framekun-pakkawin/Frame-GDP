using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Vinehitbox : MonoBehaviour
{
    public float damage = 300.0f;
    public float speed = 50.0f;
    public float countdown = 0.5f;
    public float knockbackX = 1000.0f;
    public float knockbackY = 400.0f;
    bool isDestorying = false;
    void Start()
    {

    }

    void Update()
    {
        StartCoroutine(Destorying());
    }

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
    public void DestroyGameObj()
    {
        Destroy(gameObject);
    }
    IEnumerator Destorying()
    {
        if (!isDestorying)
        {
            isDestorying = true;
            yield return new WaitForSeconds(countdown);
            isDestorying = false;
            Destroy(gameObject);
        }
    }
}
