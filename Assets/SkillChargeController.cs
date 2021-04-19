using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillChargeController : MonoBehaviour
{
    public Player1Attack player1;
    public Player2Attack player2;
    public bool isplayer2 = false;
    public Image imageCooldown;
    public float cooldown = 3;
    [HideInInspector] public float cooldowntime = 0.0f;

    void Update()
    {
        if (!isplayer2)
        {
            cooldowntime = player1.charge;
            imageCooldown.fillAmount = 1 - cooldowntime;
        }
        else
        {
            cooldowntime = player2.charge;
            imageCooldown.fillAmount = 1 - cooldowntime;
        }
    }
}
