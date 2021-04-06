using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillBarController : MonoBehaviour
{
    public Image imageCooldown;
    public float cooldown = 3;
    [HideInInspector]public float cooldowntime = 0.0f;
    public summmonhelper player;
    void Update()
    {
        cooldowntime = player.Cooldowntime;
        imageCooldown.fillAmount = cooldowntime;
    }
}
