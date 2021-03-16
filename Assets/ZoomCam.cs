using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCam : MonoBehaviour
{
    public bool ZoomActive = false;
    public float Zoomspeed = 0.0325f; 
    public Vector3 []Target;
    public Camera Cam;
    void Start()
    {
        Cam = Camera.main;
    }
    public void LateUpdate()
    {
        if (ZoomActive)
        {
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 3, Zoomspeed);
        }
        else
        {
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 5, Zoomspeed);
        }
    }

}
