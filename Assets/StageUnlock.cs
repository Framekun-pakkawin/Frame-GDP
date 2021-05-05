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

    public void goTutorial()
    {
        SceneManager.LoadScene ("NewTutorial");
    }
    public void goStage1()
    {
        if(stage1Unlock)
        {
            SceneManager.LoadScene("Potae");
        }

    }
    public void goStage2()
    {
        if (stage2Unlock)
        {
            SceneManager.LoadScene("Map2");
        }
    }
    public void goStage3()
    {
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
            stage1Unlock = true;
        }
    }
}
