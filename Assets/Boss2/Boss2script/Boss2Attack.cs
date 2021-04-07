using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Attack : MonoBehaviour
{
    public Boss2Behavior boss2;
    public GameObject vine;
    public GameObject wave;
    public GameObject groundcheckvine;
    public GameObject groundcheckwave;
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
    public void toIdeal()
    {
        boss2.PlayAnimIdeal();
    }
    public void TypeChanging()
    {
        boss2.TypeChange();
    }
    public void falseAttacking()
    {
        boss2.falseisAttacking();
    }
    public void Changinghitbox()
    {
        boss2.Changinghitbox();
    }
    public void VineSummoning()
    { 
        
    }
    public void WaveSummon()
    { 
        
    }
}
