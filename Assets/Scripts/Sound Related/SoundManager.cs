using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }
    public AudioSource soundEffect;
    public AudioSource soundMusic;
    public AudioSource ellenFoots;

    public SoundType[] Sounds;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic(global::Sounds.Music);
    }
    public void PlayMusic(Sounds sound)
    {
        AudioClip clip = GetSoundClip(sound);
        if (clip != null)
        {
            soundMusic.clip = clip;
            soundMusic.Play();
        }
    }
    public void Play(Sounds sound)
    {
        AudioClip clip = GetSoundClip(sound);
        if(clip!=null)
        {
            soundEffect.PlayOneShot(clip);
        }
    }

    public void PlayMoveement()
    {
        ellenFoots.Play();
    }
    public void StopMovement()
    {
        ellenFoots.Stop(); 
    }
    
    private AudioClip GetSoundClip(Sounds sound)
    {
        SoundType item=Array.Find(Sounds, sitem => sitem.soundType==sound);
        if(item!=null)
        {
            return item.audioClip;
        }
        return null;
    }
    
}

[Serializable]
public class SoundType
{
    public Sounds soundType;
    public AudioClip audioClip;
}

public enum Sounds
{
    ButtonClick,
    Music,
    PlayerMove,
    PlayerDeath,
    EnemyDeath,
    LevelStart,
    LevelEnd
}

