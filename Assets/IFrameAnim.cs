using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IFrameAnim : MonoBehaviour
{
    SpriteRenderer []sprite = new SpriteRenderer[50];
    string tagtofind = "Player1sprite";
    string tagtochange = "Player1spritefound";
    public PlayerMovement player;
    public bool isplayer2 = false;
    private GameObject gm;

    void Start()
    {
        if (isplayer2 == true)
        {
            tagtofind = "Player2sprite";
            tagtochange = "Player2spritefound";
        }
        for (int i=0; i<sprite.Length;i++)
        {
            sprite[i] = null;
        }
        for (int i = 0; i < sprite.Length; i++)
        {
            gm = GameObject.FindGameObjectWithTag(tagtofind);
            if (gm != null)
            {
                sprite[i] = gm.GetComponent<SpriteRenderer>();
                gm.tag = tagtochange;
                gm = null;
            }
        }
    }

    void Update()
    {
        if (player.isDamaged == true)
        {
            for (int i = 0; i < sprite.Length; i++)
            {
                if (sprite[i] != null)
                {
                    SpriteRenderer currsprite = sprite[i];
                    sprite[i].material.color = new Color(currsprite.color.r, currsprite.color.g, currsprite.color.b, 0.5f);
                }
            }
        }
        else 
        {
            for (int i = 0; i < sprite.Length; i++)
            {
                if (sprite[i] != null)
                {
                    SpriteRenderer currsprite = sprite[i];
                    sprite[i].color = new Color(currsprite.color.r, currsprite.color.g, currsprite.color.b, 1.0f);
                }
            }
        }
    }
}
