using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setscreenfilter : MonoBehaviour
{
    public PlayerHp player1;
    public PlayerHp player2;
    float currentalpha = 0.0f;
    public float maxalpha = 170.0f;
    Image filter;
    void Start()
    {
        filter = gameObject.GetComponent<Image>();
    }

    void Update()
    {
        if (player1.characterswitch.IsControling)
        {
            if (player1.currentHealth < player1.maxHealth / 2.0f)
            {
                currentalpha = 2*(((player1.maxHealth/2) - player1.currentHealth)/player1.maxHealth)*(maxalpha/255.0f);
            }
            else
            {
                currentalpha = 0.0f;
            }
        }
        else
        {
            if (player2.currentHealth < player2.maxHealth / 2.0f)
            {
                currentalpha = 2*(((player2.maxHealth/2) - player2.currentHealth) / player2.maxHealth) * (maxalpha / 255.0f);
            }
            else
            {
                currentalpha = 0.0f;
            }
        }
    }
    void FixedUpdate()
    {
        Color CurrentColor = filter.color;
        filter.color = new Color(CurrentColor.r, CurrentColor.g, CurrentColor.b, currentalpha);
    }
}
