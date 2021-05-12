using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Ballpointfollow : MonoBehaviour
{
    public GameObject boss3;

    private void Update()
    {
        gameObject.transform.position = new Vector3(boss3.transform.position.x, boss3.transform.position.y+6, boss3.transform.position.z);
    }
}
