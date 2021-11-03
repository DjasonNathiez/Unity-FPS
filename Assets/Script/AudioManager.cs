using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private Sounds[] soundsSo;

    private AudioSource m_source;


    void Start()
    {
        soundsSo = Resources.LoadAll<Sounds>("Sounds");
        m_source = GetComponent<AudioSource>();
    }

    public void PlaySound(string soundName)
    {
        foreach (Sounds s in soundsSo)
        {
            if (soundName == s.name)
            {
                m_source.clip = s.clip;
                m_source.pitch = s.pitch;
                m_source.loop = s.loop;
            }
            
        }

        m_source.Play();
    }

}
