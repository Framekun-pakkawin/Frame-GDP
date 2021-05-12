using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonend : MonoBehaviour
{
    public bool inTutorial = false;
    
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player"))
        {
            EnemyStatus.Alreadydead.Clear();
            KeyItem.Alreadycollect.Clear();
            PlayerMovement.currentcheckpoint = 0;
            if (inTutorial)
            {
                StageUnlock.stage1Unlock = true;
                SceneManager.LoadScene("IntroMap1");
            }
            else
            {
                StageUnlock.stage2Unlock = true;
                SceneManager.LoadScene("Map2");
            }
        }
    }
}
