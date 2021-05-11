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

    public void Go_Play()
    {
        SceneManager.LoadScene("StageSelection");
    }


    public void Go_Exit()
    {
        Application.Quit();
    }

    public void OptionMenu()
    {
        Option.SetActive(true);
        Menu.SetActive(false);
        Audio.SetActive(false);
        Control.SetActive(true);
        isControl = true;
    }
    public void ControlMenu()
    {
        if (isControl == false)
        {
            Control.SetActive(true);
            Audio.SetActive(false);
            isControl = true;
        }

    }
    public void AudioMenu()
    {
        if (isControl == true)
        {
            Audio.SetActive(true);
            Control.SetActive(false);
            isControl = false;
        }

    }
    public void BackToMenu()
    {
        Menu.SetActive(true);
        Option.SetActive(false);
    }
}



