using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateBoss : MonoBehaviour
{
    public ZoomCam zoomcam;
    public GameObject wallback;
    public float zoomsize = 0.0f;
    bool Actived = false;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player") && !Actived)
        {
            wallback.SetActive(true);
            zoomcam.Zoom(zoomsize);
            Actived = true;
        }
    }
}
