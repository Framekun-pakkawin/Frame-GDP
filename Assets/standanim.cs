using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class standanim : MonoBehaviour
{
    Animator animator;
    public bool isplayer2 = false;
    string PlAYER_HELPED = "HelpingC1";
    string PlAYER_HELPED2 = "HelpingC2";

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();

        if (isplayer2 == true)
        {
            PlAYER_HELPED = PlAYER_HELPED2;
        }

        animator.Play(PlAYER_HELPED);
    }

    
    void Update()
    {
        
    }
}
