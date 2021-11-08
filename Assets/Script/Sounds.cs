using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


[System.Serializable]
public class Sounds
{
    public string soundName; 
    public AudioClip clip;
    public AudioMixerGroup mixerGroup;
    public float pitch = 1;
    public float volume = 1;
    public bool loop;

    [HideInInspector] public AudioSource source;
}
