using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CutscenePlay : MonoBehaviour
{
    public VideoClip clip;
    public VideoPlayer VDOplayer;
    public string scenenametoload = "xxx";
    void Start()
    {
        VDOplayer.clip = clip;
        VDOplayer.loopPointReached += EndReached;
        VDOplayer.Play();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EndReached(VDOplayer);
        }
    }
    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene(scenenametoload);
    }
}
