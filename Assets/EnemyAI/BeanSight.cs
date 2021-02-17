using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanSight : MonoBehaviour
{
    //[HideInInspector]
    public GameObject targetPlayerToChase = null;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D overlapWithObject)
    {
        if (overlapWithObject.gameObject.CompareTag("Player") == true)
        {
            targetPlayerToChase = overlapWithObject.gameObject;
        }
    }

    /*private void OnTriggerExit2D(Collider2D overlapWithObject)
    {
        if (overlapWithObject.gameObject.CompareTag("Player") == true)
        {
            targetPlayerToChase = null;
        }
    }*/
}