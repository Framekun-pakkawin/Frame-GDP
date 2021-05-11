using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map3wrapbox : MonoBehaviour
{
    public float distance = 10; 
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Player"))
        {
            hitInfo.transform.position = new Vector3(hitInfo.transform.position.x - distance, hitInfo.transform.position.y, hitInfo.transform.position.z);
        }
    }
}
