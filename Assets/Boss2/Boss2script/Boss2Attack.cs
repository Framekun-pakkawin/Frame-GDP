using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Attack : MonoBehaviour
{
    public Boss2Behavior boss2;
    public GameObject vine;
    public GameObject wave;
    public Transform groundcheckvine;
    public Transform groundcheckwave1;
    public Transform groundcheckwave2;
    public int maxvinetosummon = 5;
    public float vinedelaytime = 1.0f;
    bool isDelayed = false;
    int vinetosummon = 0;
    private void Update()
    {
        if (vinetosummon > 0)
        {
            StartCoroutine(VineDelay());
        }
    }
    IEnumerator VineDelay()
    {
        if (!isDelayed)
        {
            isDelayed = true;
            Instantiate(vine, new Vector3(boss2.target.position.x,groundcheckvine.position.y,groundcheckvine.position.z),groundcheckvine.rotation);
            yield return new WaitForSeconds(vinedelaytime);
            vinetosummon--;
            isDelayed = false;
        }
    }
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
        vinetosummon = maxvinetosummon;
    }
    public void WaveSummon()
    {
        Instantiate(wave, groundcheckwave1.position, groundcheckwave1.rotation);
        Instantiate(wave, groundcheckwave2.position, groundcheckwave2.rotation);
    }
}
