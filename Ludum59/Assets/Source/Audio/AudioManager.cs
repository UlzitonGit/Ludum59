using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;
    
    [SerializeField] private SoundLibrary soundStorage;
    
    private Dictionary<string, AudioClip> soundLibrary = new Dictionary<string, AudioClip>();
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        musicSource.loop = true;
        musicSource.playOnAwake = false;
        sfxSource.playOnAwake = false;
        soundStorage.Initialize();
    }
    
    public void AddSound(string soundName, AudioClip clip)
    {
        if (!soundLibrary.ContainsKey(soundName))
            soundLibrary.Add(soundName, clip);
    }
    
    public void Play(string soundName)
    {
        if (soundLibrary.TryGetValue(soundName, out AudioClip clip))
        {
            sfxSource.PlayOneShot(clip);
        }
    }
    
    public void PlayMusic(string soundName)
    {
        if (soundLibrary.TryGetValue(soundName, out AudioClip clip))
        {
            musicSource.clip = clip;
            musicSource.Play();
        }
    }
    
    public void StopMusic()
    {
        musicSource.Stop();
    }
}