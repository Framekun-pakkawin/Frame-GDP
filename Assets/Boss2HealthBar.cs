using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss2HealthBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;
    public Image border;
    public GameObject boss2;
    EnemyStatus boss2stat;

    void Start()
    {
        boss2stat = boss2.GetComponent<EnemyStatus>();
        SetMaxHealth(boss2stat.EnemyMaxHp);
    }
    void Update()
    {
        Setcolor();
        SetHealth(boss2stat.Enemyhp);
    }
    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(float health)
    {
        slider.value = health;
    }
    public void Setcolor()
    {
        if (boss2.CompareTag("Demon"))
        {
            fill.color = new Color(1, 0, 0, 1);
        }
        else
        {
            fill.color = new Color(0, 1, 1, 1);
        }
    }
}
