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
    public bool isBoss2 = false;
    Boss2Behavior boss2;
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
        if (isBoss2)
        {
            boss2 = gameObject.GetComponent<Boss2Behavior>();
        }
    }

    void Update()
    {
        enemyhp = Enemyhp;
        if (Input.GetKeyDown(KeyCode.T))
        {
            Enemyhp = 400;
        }
    }
    public void TakeDamage(float Damage)
    {
        Enemyhp -= Damage;
        if (gameObject.CompareTag("Demon") || gameObject.CompareTag("DoubleType"))
        {
            Instantiate(slashfx,gameObject.transform.position,gameObject.transform.rotation);
        }
        if (Enemyhp <= 0)
        {
            if (isPermenent)
            {
                Alreadydead.Add(KeyName);
            }
            if (isBoss2 == true)
            {
                boss2.isDead = true;
            }
            else
            {
                gameObject.SetActive(false);
            }
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
