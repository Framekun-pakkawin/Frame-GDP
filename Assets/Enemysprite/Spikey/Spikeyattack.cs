using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikeyattack : MonoBehaviour
{
    public bool foundplayer = false;
    public GameObject Spikey;
    public GameObject spikeprefab;
    public float timedelay = 4.0f;
    bool isAttacking = false;
    SpikeyBehavior spikeybehave;
    Animator anim;
    private void Start()
    {
        spikeybehave = Spikey.GetComponent<SpikeyBehavior>();
        anim = gameObject.GetComponent<Animator>();
    }
    public void PlayAttackAnim()
    {
        anim.Play("Spikey_Attack");
    }
    public void Attacking()
    {
        StartCoroutine(AttackingDelay());
    }
    IEnumerator AttackingDelay()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            Instantiate(spikeprefab, new Vector3(spikeybehave.target.position.x, Spikey.transform.position.y,
                                                    spikeybehave.target.position.z), spikeybehave.target.rotation);
            yield return new WaitForSeconds(timedelay);
            isAttacking = false;
        }
    }
}
