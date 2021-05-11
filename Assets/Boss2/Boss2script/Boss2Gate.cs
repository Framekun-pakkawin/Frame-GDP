using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Gate : MonoBehaviour
{
    public ZoomCam zoomcam;
    public GameObject boss2;
    public GameObject wall1;
    public GameObject wall2;
    public GameObject boss2hpbar;
    public float zoomsize = 0.0f;
    Boss2Behavior boss2code;
    bool Actived = false;
    void Start()
    {
        boss2code = boss2.GetComponent<Boss2Behavior>();
    }

    void Update()
    {
        if (boss2code.isDead)
        {
            wall1.SetActive(false);
            wall2.SetActive(false);
            boss2hpbar.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player") && !Actived)
        {
            wall1.SetActive(true);
            wall2.SetActive(true);
            boss2hpbar.SetActive(true);
            zoomcam.Zoom(zoomsize);
            Actived = true;
        }
    }
}
