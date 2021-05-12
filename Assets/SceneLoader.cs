using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string scenenametoload = "xxx";
    public bool endofMap1 = false;
    public bool endofMap2 = false;
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(scenenametoload);
            PlayerMovement.currentcheckpoint = 0;
            if (endofMap1)
            {
                StageUnlock.stage2Unlock = true;
            }
            if (endofMap2)
            {
                StageUnlock.stage3Unlock = true;
            }
        }
    }
}
