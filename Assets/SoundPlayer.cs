using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public static List<string> Alreadyplay = new List<string>();
    public string maintheme = "xxx";
    AudioManager audiomanager;

    void Start()
    {
        GameObject AM = GameObject.Find("AudioManager");
        audiomanager = AM.GetComponent<AudioManager>();
        if (!Alreadyplay.Contains(maintheme))
        {
            audiomanager.StopAll();
            audiomanager.Play(maintheme);
            Alreadyplay.Add(maintheme);
        }
    }
}
