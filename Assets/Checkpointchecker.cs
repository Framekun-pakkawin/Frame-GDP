using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpointchecker : MonoBehaviour
{
    public GameObject player;
    public GameObject checkpoint0;
    public GameObject checkpoint1;
    void Start()
    {
        if (PlayerMovement.currentcheckpoint == 0)
        {
            player.transform.position = checkpoint0.transform.position;
        }
        else if (PlayerMovement.currentcheckpoint == 1)
        {
            player.transform.position = checkpoint1.transform.position;
        }
    }

    void Update()
    {
        
    }
}
