using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource sfxAudioSource, musicAudioSource;

    public static AudioManager instance {get; private set;}

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        sfxAudioSource.PlayOneShot(clip);
    }

    public float VolumeMusic() { return musicAudioSource.volume; }

    public float VolumeSFX() { return sfxAudioSource.volume; }

    public void VolumeDownMusic()
    {
        musicAudioSource.volume = Mathf.Clamp(musicAudioSource.volume - 0.05f, 0, 0.5f);
    }

    public void VolumeUpMusic()
    {
        musicAudioSource.volume = Mathf.Clamp(musicAudioSource.volume + 0.05f, 0, 0.5f);
    } 

    public void VolumeDownSFX()
    {
        sfxAudioSource.volume = Mathf.Clamp(sfxAudioSource.volume - 0.1f, 0, 1);
    }

    public void VolumeUpSFX()
    {
        sfxAudioSource.volume = Mathf.Clamp(sfxAudioSource.volume + 0.1f, 0, 1);
    } 
}
