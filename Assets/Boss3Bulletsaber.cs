using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Bulletsaber : MonoBehaviour
{
    public float speed = 20.0f;
    public float bulletdamage = 50.0f;
    public float distance = 50.0f;
    public float countdown = 1.0f;
    bool isDestorying = false;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
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
            player.TakeDamage(bulletdamage);
            Destroy(gameObject);
        }
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
