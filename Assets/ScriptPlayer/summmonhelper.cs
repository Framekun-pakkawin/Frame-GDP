using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class summmonhelper : MonoBehaviour
{
    public GameObject Standtosummon;
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
                if (Input.GetButtonDown("Attack2"))
                {
                    Instantiate(Standtosummon, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2.5f, 
                                                    gameObject.transform.position.z), gameObject.transform.rotation);
                }
            }
            else
            {
                if (Input.GetButtonDown("Attack1"))
                {
                    Instantiate(Standtosummon, gameObject.transform.position, gameObject.transform.rotation);
                }
            }
        }
    }
}
