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
            if (inTutorial)
            {
                SoundPlayer.Alreadyplay.Clear();
                SceneManager.LoadScene("Potae");
            }
            else
            {
                SoundPlayer.Alreadyplay.Clear();
                PlayerMovement.currentcheckpoint = 0;
                SceneManager.LoadScene("Map2");
            }
        }
    }
}
