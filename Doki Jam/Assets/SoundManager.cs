using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AudioName
{
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
    public List<float> backgroundLength;
    public List<float> backgroundCurrent;
    private AudioSource musicSource;
    private float musicTarget;
    private List<AudioSource> SFXSources;

    void Start()
    {
        SFXSources = new List<AudioSource>();
        musicSource = transform.GetChild(0).GetComponent<AudioSource>();
        SFXSources.Add(transform.GetChild(1).GetComponent<AudioSource>());
        SFXSources.Add(transform.GetChild(2).GetComponent<AudioSource>());
        SFXSources.Add(transform.GetChild(3).GetComponent<AudioSource>());
        SFXSources.Add(transform.GetChild(4).GetComponent<AudioSource>());
    }

    void Update()
    {

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

    public void PlayBackground(AudioName audio, float volume = 0.5f)
    {
        if (!musicSource.isPlaying)
        {
            musicSource.clip = soundList[(int)audio];
            musicSource.Play();
        }
        else
        {
            if (musicSource.clip != soundList[(int)audio])
            {
                musicSource.clip = soundList[(int)audio];
                musicSource.Play();
            }
        }
    }

    public void BackgroundVolume(float volume)
    {
        musicTarget = volume;
    }
}