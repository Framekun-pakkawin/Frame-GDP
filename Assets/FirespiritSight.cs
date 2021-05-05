using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirespiritSight : MonoBehaviour
{
    public NewFirespiritsBehavior firespirits;
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player"))
        {
            firespirits.target = hitInfo.transform;
        }
    }
}
