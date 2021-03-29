using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destorycloneobj : MonoBehaviour
{
    public float countdown = 1.0f;
    bool isDestorying = false;
    void Start()
    {

    }
    void Update()
    {
        StartCoroutine(DestoryCountdown());
    }
    public void DestoryGameObj()
    {
        Destroy(gameObject);
    }
    IEnumerator DestoryCountdown()
    {
        if (!isDestorying)
        {
            isDestorying = true;
            yield return new WaitForSeconds(countdown);
            isDestorying = false;
            Destroy(gameObject);
        }
    }
    
}
