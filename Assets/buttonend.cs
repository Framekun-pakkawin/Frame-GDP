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
            if (inTutorial)
            {
                SceneManager.LoadScene("Potae");
            }
            else
            {
                SceneManager.LoadScene(3);
            }
        }
    }
}
