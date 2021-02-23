using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCenter : MonoBehaviour
{
    public CharacterSwitch player1code;
    public GameObject player1object;
    public CharacterSwitch player2code;
    public GameObject player2object;
    public Transform savespot;
    public bool isplayer1 = true;
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
                isplayer1 = false;
            }
            else if(player2code.IsControling == true)
            {
                player2code.IsControling = false;
                Switch(player1object, player2object);
                isplayer1 = true;
            }
        }
    }
    void Switch(GameObject playerin,GameObject playerout)
    {
        CharacterSwitch playerincode = playerin.GetComponent<CharacterSwitch>();
        CharacterSwitch playeroutcode = playerout.GetComponent<CharacterSwitch>();
        Transform currplayer = playerout.gameObject.transform;
        playerin.transform.position = new Vector3(currplayer.position.x, currplayer.position.y, currplayer.position.z);
        playeroutcode.IsControling = false;
        playerout.transform.position = new Vector3(savespot.position.x, savespot.position.y, savespot.position.z);
        playerincode.IsControling = true;
    }
}
