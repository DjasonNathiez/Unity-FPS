using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] [Header("Sound Effect")]
    private Sounds[] soundsList;

    public static AudioManager instance;

    [Header("Musics")] 
    public Sounds[] musicSounds;

    public int levelCount;
    
    private void Awake()
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
        
        foreach (Sounds s in soundsList)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.pitch = s.pitch;
            s.source.volume = s.volume;
        }
        
        foreach (Sounds s in musicSounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.pitch = s.pitch;
            s.source.volume = s.volume;
        }

        if (levelCount <= 1)
        {
            LoadMusic("Level 1");
        }

        if (levelCount == 2)
        {
            LoadMusic("Level 2");
        }
    }

    public void PlaySound(string name)
    {
        Sounds s = Array.Find(soundsList, sound => sound.soundName == name);
        s.source.Play();
    }

    public void StopSound(string name)
    {
        Sounds s = Array.Find(soundsList, sound => sound.soundName == name);
        s.source.Stop();
    }

    public void LoadMusic(string name)
    {
        Sounds s = Array.Find(musicSounds, sounds => sounds.soundName == name);
        s.source.Play();
    }
}
