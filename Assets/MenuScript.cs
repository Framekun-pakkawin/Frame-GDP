using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject Pause;
    public bool isPause;
    public GameObject Option;
    public GameObject Control;
    public GameObject Audio;
    bool isControl = true;
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
        Option.SetActive(false);
    }

    public void Go_Mainmenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void OptionMenu()
    {
        Option.SetActive(true);
        Pause.SetActive(false);
        Audio.SetActive(false);
        Control.SetActive(true);
        isControl = true;
    }
    public void ControlMenu()
    {
        if(isControl == false)
        {
            Control.SetActive(true);
            Audio.SetActive(false);
            isControl = true;
        }

    }
    public void AudioMenu()
    {
        if(isControl == true)
        {
            Audio.SetActive(true);
            Control.SetActive(false);
            isControl = false;
        }
   
    }
    public void BackToPause()
    {
        Pause.SetActive(true);
        Option.SetActive(false);
    }
}

