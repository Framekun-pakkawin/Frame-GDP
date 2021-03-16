using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBehavior : MonoBehaviour
{
    public GameObject bulletprefab;
    public Transform firepoint;
    public float shootingdelay = 1.0f;
    bool bulletiscooldown = false;
    bool MovingUp = true;
    float startpositionY;
    Rigidbody2D rb;
    public float movingspeed = 10.0f;
    public float Patroldistance = 10.0f; 
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        startpositionY = gameObject.transform.position.y;
    }

    void Update()
    {
        Patrol();
        Shooting();
    }
    void Patrol()
    {
        if (MovingUp)
        {
            rb.velocity = transform.up * movingspeed;
        }
        else
        {
            rb.velocity = -transform.up * movingspeed;
        }
        if (Mathf.Abs(startpositionY - gameObject.transform.position.y) >= Patroldistance)
        {
            MovingUp = false;
        }
        else if ((gameObject.transform.position.y - startpositionY) <= 0)
        {
            MovingUp = true;
        }
    }
    void Shooting()
    {
        StartCoroutine(Shootdelay());
    }
    IEnumerator Shootdelay()
    {
        if (!bulletiscooldown)
        {
            bulletiscooldown = true;
            Instantiate(bulletprefab, firepoint.position, firepoint.rotation);
            yield return new WaitForSeconds(shootingdelay);
            bulletiscooldown = false;
        }
    }
}
