using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public string MainMenu;
    public GameObject Pause;
    public bool isPause;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPause)
            {
                resumeGame();
            }
            else
            {
                isPause = true;
                Pause.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }
    public void Go_Tutorial()
    {
        SceneManager.LoadScene(1);
    }
    public void Go_Play()
    {
        SceneManager.LoadScene(2);
    }


    public void Go_Exit ()
    {
        Application.Quit();
    }

    public void resumeGame()
    {
        isPause = false;
        Pause.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Go_Mainmenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}

