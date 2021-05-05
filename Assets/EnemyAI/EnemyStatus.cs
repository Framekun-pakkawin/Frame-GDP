using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public static List<string> Alreadydead = new List<string>();
    public string KeyName = "";
    public bool isPermenent = false;
    public float EnemyMaxHp = 20.0f;
    [HideInInspector] public float Enemyhp = 20.0f;
    public bool knockbackright = true;
    public bool isknockbackable = true;
    public float enemyhp = 20.0f;
    public GameObject slashfx;
    Rigidbody2D rb;
    void Start()
    {
        Enemyhp = EnemyMaxHp;
        rb = gameObject.GetComponent<Rigidbody2D>();
        if (Alreadydead.Contains(KeyName))
        {
            Enemyhp = 0;
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        enemyhp = Enemyhp;
    }
    public void TakeDamage(float Damage)
    {
        Enemyhp -= Damage;
        if (gameObject.CompareTag("Demon"))
        {
            Instantiate(slashfx,gameObject.transform.position,gameObject.transform.rotation);
        }
        if (Enemyhp <= 0)
        {
            if (isPermenent)
            {
                Alreadydead.Add(KeyName);
            }
            gameObject.SetActive(false);
        }
    }
    public void knockback(float forceX, float forceY)
    {
        if (isknockbackable)
        {
            if (knockbackright == false)
            {
                forceX = -forceX;
            }
            rb.AddForce(new Vector2(forceX, forceY));
        }
    }
}
