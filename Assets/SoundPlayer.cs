using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public string maintheme = "xxx";
    AudioManager audiomanager;

    void Start()
    {
        GameObject AM = GameObject.Find("AudioManager");
        audiomanager = AM.GetComponent<AudioManager>();
        if (!audiomanager.isPlaying(maintheme))
        {
            audiomanager.StopAll();
            audiomanager.Play(maintheme);
        }
        audiomanager.Stop("Walking");
    }
}
