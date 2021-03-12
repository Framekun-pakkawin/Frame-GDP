using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }

    public string mainMenuLevel1;

    public void RestartGame()
    {

    }

    public void QuitToMain()
    {
        SceneManager.LoadScene(0);
    }
}
