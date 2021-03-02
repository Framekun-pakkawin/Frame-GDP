using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2helpP1 : MonoBehaviour
{
    public GameObject HitBox;
    public PlayerMovement playermove;
    public CharacterSwitch switchplayer;
    private void Start()
    {
        
    }
    void Update()
    {
        if (switchplayer.IsControling == true)
        {
            if (Input.GetButtonDown("Attack2") && playermove.isHelped == false)
            {
                playermove.isHelped = true;
            }
        }
    }
    public void Active_helpinghitBox()
    {
        HitBox.SetActive(true);
    }

    public void Deactive_helpinghitBox()
    {
        HitBox.SetActive(false);
    }
}
