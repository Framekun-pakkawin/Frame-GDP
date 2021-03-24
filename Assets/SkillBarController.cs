using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillBarController : MonoBehaviour
{
    public Image imageCooldown;
    public float cooldown = 5;
    bool isCooldown;
    void Update()
    {
        if(Input.GetKey(KeyCode.Alpha1))
        {
            isCooldown = true;
        }

        if(isCooldown)
        {
            imageCooldown.fillAmount += 1 / cooldown * Time.deltaTime;

            if(imageCooldown.fillAmount == 1)
            {
                imageCooldown.fillAmount = 0;
                isCooldown = false;
            }
        }

    }
}
