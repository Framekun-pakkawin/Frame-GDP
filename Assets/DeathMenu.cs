using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    string scenename;
    private void Start()
    {
        scenename = SceneManager.GetActiveScene().name;
        gameObject.SetActive(false);
    }

    public string mainMenuLevel1;

    public void RestartGame()
    {
        SceneManager.LoadScene(scenename);
    }

    public void QuitToMain()
    {
        SceneManager.LoadScene(0);
    }
}
