using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class summmonhelper : MonoBehaviour
{
    public GameObject Standtosummon;
    public float helpingcooldown = 1.0f;
    public float Cooldowntime = 0.0f;
    [HideInInspector] public bool isCooldown = false;
    AnimationControl animControl;
    CharacterSwitch switchplayer;
    private void Start()
    {
        switchplayer = gameObject.GetComponent<CharacterSwitch>();
        animControl = gameObject.GetComponent<AnimationControl>();
    }
    void Update()
    {

        if (switchplayer.IsControling == true)
        {
            if (animControl.isplayer2 == false)
            {
                if (Input.GetButtonDown("Attack2") && !isCooldown)
                {
                    Instantiate(Standtosummon, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2.5f, 
                                                    gameObject.transform.position.z), gameObject.transform.rotation);
                    StartCoroutine(Cooldown());
                }
            }
            else
            {
                if (Input.GetButtonDown("Attack1") && !isCooldown)
                {
                    Instantiate(Standtosummon, gameObject.transform.position, gameObject.transform.rotation);
                    StartCoroutine(Cooldown());
                }
            }
        }
        if (isCooldown)
        {
            Cooldowntime += 1 / helpingcooldown * Time.deltaTime;
            if (Cooldowntime == 1)
            {
                Cooldowntime = 0;
            }
        }
        else
        {
            Cooldowntime = 0;
        }
    }
    IEnumerator Cooldown()
    {
        if (!isCooldown)
        {
            isCooldown = true;
            yield return new WaitForSeconds(helpingcooldown);
            isCooldown = false;
        }
    }
}
