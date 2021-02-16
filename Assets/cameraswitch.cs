using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class cameraswitch : MonoBehaviour
{
    public SwitchCenter switchcenter;
    public Transform player1;
    public Transform player2;
    public CinemachineVirtualCamera cam;
    void Start()
    {
        
    }

    void Update()
    {
        if (switchcenter.isplayer1 == true)
        {
            cam.Follow = player1;
        }
        else 
        {
            cam.Follow = player2;
        }
    }
}
