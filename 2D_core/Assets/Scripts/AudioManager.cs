using UnityEngine.Audio;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager audioManagerInstance;

   
    void Awake()
    {
        if(audioManagerInstance == null)
        {
            audioManagerInstance = this;
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
            s.source.priority = s.priority;
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
   
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void PlayRandom()
    {
        var rand = new System.Random();
        int choice = rand.Next(sounds.Length);
        Sound s = sounds[choice];
        s.source.Play();
    }
}
