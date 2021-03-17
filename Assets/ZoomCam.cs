using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ZoomCam : MonoBehaviour
{
    public bool ZoomActive = false;
    public float sizetozoom = 6.0f;
    public float normalsize = 5.0f;
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
