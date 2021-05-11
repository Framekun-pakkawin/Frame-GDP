using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RealMenu : MonoBehaviour
{
    public GameObject Menu;
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
    public void Go_Play()
    {
        audiomanager.Play(soundname);
        SceneManager.LoadScene("StageSelection");
    }
    public void Go_Exit()
    {
        audiomanager.Play(soundname);
        Application.Quit();
    }

    public void OptionMenu()
    {
        audiomanager.Play(soundname);
        Option.SetActive(true);
        Menu.SetActive(false);
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
    public void BackToMenu()
    {
        audiomanager.Play(soundname);
        Menu.SetActive(true);
        Option.SetActive(false);
    }
}



