using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public Image border;
    public PlayerHp playerhp;

    void Update()
    {
        fill.color = new Color(fill.color.r, fill.color.g, fill.color.b,1.0f- (playerhp.currentHealth/ playerhp.maxHealth));
        border.color = new Color(border.color.r, border.color.g, border.color.b, 1.0f - (playerhp.currentHealth / playerhp.maxHealth));

    }
    public void SetMaxHealth(float health) 
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(float health) 
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
