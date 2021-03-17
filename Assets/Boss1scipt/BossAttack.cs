using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public GameObject handhitbox;
    public GameObject beamhitbox;

    public void ActiveHandhitbox()
    {
        handhitbox.SetActive(true);
    }
    public void DeactiveHandhitbox()
    {
        handhitbox.SetActive(false);
    }
    public void ActiveBeamhitbox()
    {
        beamhitbox.SetActive(true);
    }
    public void DeactiveBeamhitbox()
    {
        beamhitbox.SetActive(false);
    }
}
