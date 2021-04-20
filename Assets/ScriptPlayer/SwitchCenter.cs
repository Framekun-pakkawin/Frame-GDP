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
    public bool Switching = false;
    public GameObject switchfx;
    KeyCode player1key = KeyCode.E;
    KeyCode player2key = KeyCode.Mouse1;
    bool isDelay = false;
    public float timedelay = 1.0f;
    void Start()
    {
        
    }
    void Update()
    {
        if (!isDelay)
        {
            if (player1code.IsControling == true)
            {
                if (Input.GetKeyDown(player1key))
                {
                    Switching = true;
                    player1code.IsControling = false;
                    Switch(player2object, player1object);
                    isplayer1 = false;
                    StartCoroutine(SwitchDelay());
                }
            }
            else if (player2code.IsControling == true)
            {
                if (Input.GetKeyDown(player2key))
                {
                    Switching = true;
                    player2code.IsControling = false;
                    Switch(player1object, player2object);
                    isplayer1 = true;
                    StartCoroutine(SwitchDelay());
                }
            }
        }
    }
    void Switch(GameObject playerin,GameObject playerout)
    {
        CharacterSwitch playerincode = playerin.GetComponent<CharacterSwitch>();
        CharacterSwitch playeroutcode = playerout.GetComponent<CharacterSwitch>();
        Transform currplayer = playerout.gameObject.transform;
        Instantiate(switchfx, currplayer.position, switchfx.transform.rotation);
        playerin.transform.position = new Vector3(currplayer.position.x, currplayer.position.y, currplayer.position.z);
        playeroutcode.IsControling = false;
        playerout.transform.position = new Vector3(savespot.position.x, savespot.position.y, savespot.position.z);
        playerincode.IsControling = true;
    }
    IEnumerator SwitchDelay()
    {
        if (!isDelay)
        {
            isDelay = true;
            yield return new WaitForSeconds(timedelay);
            isDelay = false;
        }
    }
}
