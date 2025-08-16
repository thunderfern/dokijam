using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AudioName
{
    Jam,
    Explosion,
    Win,
    Click,
    Shoot,
    Jump,
    Null
}

public class SoundManager : MonoBehaviour
{

    // Singleton

    private static SoundManager _instance;

    private SoundManager()
    {
        _instance = this;

    }

    public static SoundManager instance()
    {
        if (_instance == null)
        {
            SoundManager instance = new SoundManager();
            _instance = instance;
        }
        return _instance;
    }

    public AudioClip[] soundList;
    public AudioClip[] backgroundList;
    private List<AudioSource> SFXSources;

    void Start()
    {
        SFXSources = new List<AudioSource>();
        SFXSources.Add(transform.GetChild(0).GetComponent<AudioSource>());
        SFXSources.Add(transform.GetChild(1).GetComponent<AudioSource>());
        SFXSources.Add(transform.GetChild(2).GetComponent<AudioSource>());
        SFXSources.Add(transform.GetChild(3).GetComponent<AudioSource>());
    }

    void Update()
    {
        // if (Input.GetMouseButtonDown(0))
        // {
        //     PlaySound(AudioName.Jam, 0.36f);
        // }
        // if (Input.GetMouseButtonDown(0))
        // {
        //     PlaySound(AudioName.Explosion, 0.99f);
        // }
        // if (Input.GetMouseButtonDown(0))
        // {
        //     PlaySound(AudioName.Win, 0.33f);
        // }
        // if (Input.GetMouseButtonDown(0))
        // {
        //     PlaySound(AudioName.Click, 0.99f);
        // }
        // if (Input.GetMouseButtonDown(0))
        // {
        //     PlaySound(AudioName.Shoot, 0.36f);
        // }
        // if (Input.GetMouseButtonDown(0))
        // {
        //     PlaySound(AudioName.Jump, 0.99f);
        // }
    }


    bool checkPlaying(AudioName audio)
    {
        for (int i = 0; i < 4; i++)
        {
            if (!SFXSources[i].isPlaying) continue;
            if (SFXSources[i].clip == soundList[(int)audio]) return true;
        }
        return false;
    }

    void playFirst(AudioName audio, float volume)
    {
        for (int i = 0; i < 4; i++)
        {
            if (!SFXSources[i].isPlaying)
            {
                SFXSources[i].volume = volume;
                SFXSources[i].clip = soundList[(int)audio];
                SFXSources[i].Play();
                return;
            }
        }
    }

    public void StopSound(AudioName audio)
    {
        if (audio == AudioName.Null) return;
        for (int i = 0; i < 4; i++)
        {
            if (SFXSources[i].clip == soundList[(int)audio])
            {
                SFXSources[i].Stop();
            }
        }
    }

    public void PlaySound(AudioName audio, float volume = 1)
    {
        if (!checkPlaying(audio))
        {
            playFirst(audio, volume);
        }
    }

}