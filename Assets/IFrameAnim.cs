using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IFrameAnim : MonoBehaviour
{
    public Material playermat;
    public PlayerMovement player;

    public int delayframe = 5;
    public float iframedelay = 0.5f;

    bool iframe = false;
    float appear = 1.0f;
    float disappear = 0.0f;
    float halfappear = 0.5f;
    float curralpha = 1.0f;


    void Start()
    {
        
    }

    void Update()
    {
        if (player.isDamaged == true)
        {
            StartCoroutine(Iframeanim());
        }
        else 
        {
            SetMaterialAlpha(appear);
        }
    }
    IEnumerator Iframeanim()
    {
        if (!iframe)
        {
            iframe = true;
            SetMaterialAlpha(halfappear);
            yield return new WaitForSeconds(iframedelay);
            SetMaterialAlpha(appear);
            yield return new WaitForSeconds(iframedelay);
            iframe = false;
        }
    }
    void SetMaterialAlpha(float a)
    {
        Color currcolor = playermat.color;
        playermat.color = new Color(currcolor.r, currcolor.g, currcolor.b, a);
    }
}
