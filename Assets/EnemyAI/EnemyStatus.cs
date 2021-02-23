using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public float Enemyhp = 20.0f;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void TakeDamage(float Damage)
    {
        Enemyhp -= Damage;
        if (Enemyhp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
