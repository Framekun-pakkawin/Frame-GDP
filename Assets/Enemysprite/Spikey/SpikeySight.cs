using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeySight : MonoBehaviour
{
    public SpikeyBehavior spikey;
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player"))
        {
            spikey.target = hitInfo.transform;
        }
    }
    private void OnTriggerStay2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player"))
        {
            spikey.target = hitInfo.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player"))
        {
            spikey.target = null;
        }
    }
}
