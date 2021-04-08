using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Gate : MonoBehaviour
{
    public ZoomCam zoomcam;
    public GameObject boss2;
    public GameObject wall1;
    public GameObject wall2;
    public float zoomsize = 0.0f;
    bool Actived = false;
    void Start()
    {

    }

    void Update()
    {
        if (!boss2.activeSelf)
        {
            wall1.SetActive(false);
            wall2.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player") && !Actived)
        {
            wall1.SetActive(true);
            wall2.SetActive(true);
            zoomcam.Zoom(zoomsize);
            Actived = true;
        }
    }
}
