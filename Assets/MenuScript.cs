using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
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
}
