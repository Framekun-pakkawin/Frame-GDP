using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageUnlock : MonoBehaviour
{

    static public bool stage1Unlock = false;
    static public bool stage2Unlock = false;
    static public bool stage3Unlock = false;

    public GameObject Lock1;
    public GameObject Lock2;
    public GameObject Lock3;

    public string soundname = "xxx";
    AudioManager audiomanager;

    void Start()
    {
        GameObject AM = GameObject.Find("AudioManager");
        audiomanager = AM.GetComponent<AudioManager>();
    }
    public void goTutorial()
    {
        audiomanager.Play(soundname);
        SoundPlayer.Alreadyplay.Clear();
        SceneManager.LoadScene ("NewTutorial");
    }
    public void goStage1()
    {
        audiomanager.Play(soundname);
        SoundPlayer.Alreadyplay.Clear();
        if (stage1Unlock)
        {
            SceneManager.LoadScene("Potae");
        }

    }
    public void goStage2()
    {
        audiomanager.Play(soundname);
        SoundPlayer.Alreadyplay.Clear();
        if (stage2Unlock)
        {
            SceneManager.LoadScene("Map2");
        }
    }
    public void goStage3()
    {
        audiomanager.Play(soundname);
        SoundPlayer.Alreadyplay.Clear();
        if (stage3Unlock)
        {
            SceneManager.LoadScene("Map3");
        }
    }
    private void Update()
    {
        if(stage1Unlock == true)
        {
            Lock1.SetActive(false);
        }
        if (stage2Unlock == true)
        {
            Lock2.SetActive(false);
        }
        if (stage3Unlock == true)
        {
            Lock3.SetActive(false);
        }
        if (Input.GetKey(KeyCode.F1))
        {
            stage2Unlock = true;
        }
    }
    public void Go_StageGoBack()
    {
        audiomanager.Play(soundname);
        SceneManager.LoadScene("Main_Menu");
    }
}
