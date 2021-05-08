using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Status2 : MonoBehaviour
{
    public float EnemyMaxHp = 20.0f;
    [HideInInspector] public float Enemyhp = 20.0f;
    public GameObject slashfx;
    public Boss2Behavior boss2;
    Rigidbody2D rb;
    void Start()
    {
        Enemyhp = EnemyMaxHp;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Enemyhp <= 0)
        {
            boss2.isDead = true;
        }
    }
    public void TakeDamage(float Damage)
    {
        Enemyhp -= Damage;
        if (gameObject.CompareTag("Demon"))
        {
            Instantiate(slashfx, gameObject.transform.position, gameObject.transform.rotation);
        }
        if (Enemyhp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
