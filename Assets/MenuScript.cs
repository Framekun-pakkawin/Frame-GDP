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

    public string soundname = "xxx";
    AudioManager audiomanager;

    void Start()
    {
        GameObject AM = GameObject.Find("AudioManager");
        audiomanager = AM.GetComponent<AudioManager>();
    }
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
        SceneManager.LoadScene("NewTutorial");
    }
    public void Go_Play()
    {
        SceneManager.LoadScene("Potae");
    }


    public void Go_Exit ()
    {
        audiomanager.Play(soundname);
        Application.Quit();
    }

    public void resumeGame()
    {
        audiomanager.Play(soundname);
        isPause = false;
        Pause.SetActive(false);
        Time.timeScale = 1f;
        Option.SetActive(false);
    }

    public void Go_Mainmenu()
    {
        audiomanager.Play(soundname);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void OptionMenu()
    {
        audiomanager.Play(soundname);
        Option.SetActive(true);
        Pause.SetActive(false);
        Audio.SetActive(false);
        Control.SetActive(true);
        isControl = true;
    }
    public void ControlMenu()
    {
        audiomanager.Play(soundname);
        if (isControl == false)
        {
            Control.SetActive(true);
            Audio.SetActive(false);
            isControl = true;
        }

    }
    public void AudioMenu()
    {
        audiomanager.Play(soundname);
        if (isControl == true)
        {
            Audio.SetActive(true);
            Control.SetActive(false);
            isControl = false;
        }
   
    }
    public void BackToPause()
    {
        audiomanager.Play(soundname);
        Pause.SetActive(true);
        Option.SetActive(false);
    }
}

