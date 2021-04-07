using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Attack : MonoBehaviour
{
    public Boss2Behavior boss2;
    public void FallingDown()
    {
        boss2.PlayAnimFallingDown();
    }
    public void RedtoBlue()
    {
        boss2.PlayAnimRedtoBlue();
    }
    public void RisingUp()
    {
        boss2.PlayAnimRisingUp();
    }
    public void falseAttacking()
    {
        boss2.falseisAttacking();
    }
    public void Changinghitbox()
    {
        boss2.Changinghitbox();
    }
}
