using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpanimswitch : MonoBehaviour
{
    public GameObject hpbar1;
    public GameObject hpbar2;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    [ContextMenu("switchhpbar")]
    void SwitchHpBar()
    {
        int hp1index = hpbar1.transform.GetSiblingIndex();
        int hp2index = hpbar2.transform.GetSiblingIndex();
        hpbar1.transform.SetSiblingIndex(hp2index);
        hpbar2.transform.SetSiblingIndex(hp1index);
    }
}
