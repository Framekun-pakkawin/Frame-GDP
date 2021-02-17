using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slashhitbox : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Enemy"))
        { 
            
        }
    }

}
