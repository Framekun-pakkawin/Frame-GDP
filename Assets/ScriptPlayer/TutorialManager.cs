using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    public int popUpIndex;
    public float Delay = 2.00f;
    bool isDelay = false;
    IEnumerator pressDelay()
    {
        isDelay = true;

        yield return new WaitForSeconds(Delay);
        isDelay = false;
       
    }
    void changeIndex()
    {
        if (isDelay == false)
        {
            popUps[popUpIndex].SetActive(false);
            popUpIndex++;
            popUps[popUpIndex].SetActive(true);
            StartCoroutine(pressDelay());
        }
    }

    void Update()
    {
        if (popUpIndex == 0)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                changeIndex();
            }
        }
        else if (popUpIndex == 1)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                changeIndex();
            }
        }
        else if (popUpIndex == 2)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                changeIndex();
            }
        }
        else if (popUpIndex == 3)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                changeIndex();
            }
        }
        else if (popUpIndex == 4)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                changeIndex();
            }
        }
        else if (popUpIndex == 5)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                changeIndex();
            }
        }


    }
}
