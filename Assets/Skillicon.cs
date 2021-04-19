using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skillicon : MonoBehaviour
{
    public SwitchCenter switchcenter;
    public GameObject skillhelper1;
    public GameObject skillhelper2;
    public GameObject skillcharge1;
    public GameObject skillcharge2;
    void Update()
    {
        if (switchcenter.isplayer1)
        {
            skillhelper1.SetActive(true);
            skillcharge1.SetActive(true);
            skillhelper2.SetActive(false);
            skillcharge2.SetActive(false);
        }
        else
        {
            skillhelper1.SetActive(false);
            skillcharge1.SetActive(false);
            skillhelper2.SetActive(true);
            skillcharge2.SetActive(true);
        }
    }
}
