using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpanimswitch : MonoBehaviour
{
    public GameObject hpbar1;
    public GameObject hpbar2;
    public SwitchCenter switchcenter;
    Animator hp1anim;
    Animator hp2anim;
    void Start()
    {
        hp1anim = hpbar1.GetComponent<Animator>();
        hp2anim = hpbar2.GetComponent<Animator>();
    }

    void Update()
    {
        if (switchcenter.Switching == true)
        {
            if (hp1anim.GetCurrentAnimatorStateInfo(0).IsName("P1Healthbar2anim"))
            {
                hp1anim.Play("P1Healthbar1anim");
                hp2anim.Play("P2Healthbar1anim");
            }
            else if(hp1anim.GetCurrentAnimatorStateInfo(0).IsName("P1Healthbar1anim"))
            {
                hp1anim.Play("P1Healthbar2anim");
                hp2anim.Play("P2Healthbar2anim");
            }
            switchcenter.Switching = false;
        }
    }
    void SwitchHpBar()
    {
        int hp1index = hpbar1.transform.GetSiblingIndex();
        int hp2index = hpbar2.transform.GetSiblingIndex();
        hpbar1.transform.SetSiblingIndex(hp2index);
        hpbar2.transform.SetSiblingIndex(hp1index);
    }
}
