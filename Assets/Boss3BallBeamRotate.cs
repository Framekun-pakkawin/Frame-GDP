using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3BallBeamRotate : MonoBehaviour
{
    GameObject currtarget;
    SwitchCenter switchcenter;
    public GameObject Beam;
    public float DelayBeam = 5.0f;
    public float MaxScale = 5.0f;
    float CurrScale = 0.5f;
    bool isStarting = false;
    bool isShooting = false;
    void Start()
    {
        GameObject switchcenterobj;
        switchcenterobj = GameObject.Find("switchcenter");
        switchcenter = switchcenterobj.GetComponent<SwitchCenter>();
    }
    void Update()
    {
        if (!isStarting)
        {
            StartCoroutine(BeamDelaying());
        }
        if (!isShooting)
        {
            if (switchcenter.isplayer1)
            {
                currtarget = switchcenter.player1object;
            }
            else
            {
                currtarget = switchcenter.player2object;
            }
            BeamRotating();
        }
        else
        {
            CurrScale += MaxScale * Time.deltaTime;
            if (CurrScale >= MaxScale)
            {
                Destroy(gameObject);
            }
            Beam.transform.localScale = new Vector3(CurrScale, Beam.transform.localScale.y, Beam.transform.localScale.z);
        }
    }
    void BeamRotating()
    {
        Vector3 targetDir = currtarget.transform.position - Beam.transform.position;
        float angle = Vector3.SignedAngle(targetDir, transform.right,Vector3.forward);
        Quaternion beamrotation = Quaternion.Euler(0,0,-angle);
        Beam.transform.rotation = beamrotation;
    }
    IEnumerator BeamDelaying()
    {
        if (!isStarting)
        {
            isStarting = true;
            yield return new WaitForSeconds(DelayBeam);
            isShooting = true;
        }
    }
}
