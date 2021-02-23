using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    public int popUpIndex;

    private void Update()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpIndex)
            {
                popUps[popUpIndex].SetActive(true);
            }
            else
            {
                popUps[popUpIndex].SetActive(false);
            }
        }

        if (popUpIndex == 0)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                popUpIndex++;
            }
        }

        else if (popUpIndex == 1)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 2)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                popUpIndex++;
            }

        }
        else if (popUpIndex == 3)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                popUpIndex++;
            }

        }
        else if (popUpIndex == 3)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                popUpIndex++;
            }

        }

    }
}
