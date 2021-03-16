using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikehitbox : MonoBehaviour
{
    public float damage = 100.0f;
    public float timedelay = 0.5f;
    bool isAppear = false;
    void Update()
    {
        StartCoroutine(Disappear());
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player"))
        {
            PlayerMovement playercode = hitInfo.GetComponent<PlayerMovement>();
            playercode.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
    IEnumerator Disappear()
    {
        if (!isAppear)
        {
            isAppear = true;
            yield return new WaitForSeconds(timedelay);
            isAppear = false;
            Destroy(gameObject);
        }
    }
}
