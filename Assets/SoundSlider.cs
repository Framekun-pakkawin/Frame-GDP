using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    public Slider slider;
    public bool isMusic;
    void Update()
    {
        if (isMusic)
        {
            slider.value = AudioManager.musicvolume;
        }
        else
        {
            slider.value = AudioManager.fxvolume;
        }
    }
    public void ChangingValue()
    {
        if (isMusic)
        {
            AudioManager.musicvolume = slider.value;
        }
        else
        {
            AudioManager.fxvolume = slider.value;
        }
    }
}
