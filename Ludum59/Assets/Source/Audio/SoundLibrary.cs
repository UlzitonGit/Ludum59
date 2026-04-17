using System;
using UnityEngine;

[Serializable]
public class SoundLibrary
{
    [System.Serializable]
    public class SoundEntry
    {
        public string name;
        public AudioClip clip;
    }
    
    [SerializeField] private SoundEntry[] sounds;
    
    public void Initialize()
    {
        foreach (var sound in sounds) 
        {
            AudioManager.Instance.AddSound(sound.name, sound.clip);
        }
    }
}