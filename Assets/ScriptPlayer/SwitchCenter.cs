using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCenter : MonoBehaviour
{
    public CharacterSwitch player1code;
    public GameObject player1object;
    public CharacterSwitch player2code;
    public GameObject player2object;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (player1code.IsControling == true)
            {
                player1code.IsControling = false;
                Switch(player2object, player1object);
            }
            else if(player2code.IsControling == true)
            {
                player2code.IsControling = false;
                Switch(player1object, player2object);
            }
        }
    }
    void Switch(GameObject playerin,GameObject playerout)
    {
        Transform currplayer = playerout.gameObject.transform;
        playerin.transform.position = new Vector3(currplayer.position.x, currplayer.position.y, currplayer.position.z);
        playerin.SetActive(true);
    }
}
