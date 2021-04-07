using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ZoomCam : MonoBehaviour
{
    CinemachineVirtualCamera virtualcam;
    void Start()
    {
        virtualcam = GetComponent<CinemachineVirtualCamera>();
    }
    void Update()
    {
        
    }
    public void Zoom(float size)
    {
        virtualcam.m_Lens.OrthographicSize = size;
    }

}
