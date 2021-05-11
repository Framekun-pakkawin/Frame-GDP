using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
    public static float fxvolume = 1.0f;
    public static float musicvolume = 1.0f;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            if (s.isMusic)
            {
                s.source.volume = s.volume* musicvolume;
            }
            else
            {
                s.source.volume = s.volume* fxvolume;
            }
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    void Start()
    {
        
    }
    void Update()
    {
        foreach (Sound s in sounds)
        {
            if (s.isMusic)
            {
                s.source.volume = s.volume * musicvolume;
            }
            else
            {
                s.source.volume = s.volume * fxvolume;
            }
        }
    }

    public void Play(string name)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == name)
            {
                s.source.Play();
            }
        }
    }
    public void StopAll()
    {
        foreach (Sound s in sounds)
        {
            s.source.Stop();
        }
    }
    public void Stop(string name)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == name)
            {
                s.source.Stop();
            }
        }
    }
}
