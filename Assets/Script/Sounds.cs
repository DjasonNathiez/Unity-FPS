using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(order = 0, fileName = "Son", menuName = "ScriptableObject/Sounds")]
public class Sounds : ScriptableObject
{
    public string name;
    public AudioClip clip;
    public AudioMixerGroup mixerGroup;
    public float pitch = 1;
    public bool loop;
    
}
