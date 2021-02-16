using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Attack : MonoBehaviour
{
    public GameObject HitBox;
    public PlayerMovement playermove;
    void Update()
    {
        if (Input.GetButtonDown("Attack1"))
        {
            playermove.ChangeAnimationState("Attack1");
        }
    }
    public void Active_hitBox()
    {
        HitBox.SetActive(true);
    }

    public void Deactive_hitBox()
    {
        HitBox.SetActive(false);
    }
}
