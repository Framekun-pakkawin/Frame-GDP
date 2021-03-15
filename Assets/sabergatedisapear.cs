using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sabergatedisapear : MonoBehaviour
{
    public float delaygate = 0.05f;
    void Start()
    {
        
    }

    void Update()
    {
        StartCoroutine(Disapear());
    }
    IEnumerator Disapear()
    {
        yield return new WaitForSeconds(delaygate);
        gameObject.SetActive(false);
    }
}
