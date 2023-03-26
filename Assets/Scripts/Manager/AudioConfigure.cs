using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioConfigure : MonoBehaviour
{
    [SerializeField] private Image fillMusic, fillSFX;
    [SerializeField] private AudioClip volumeDown, volumeUp;

    public void VolumeDownMusic()
    {
        AudioManager.instance.VolumeDownMusic();
        fillMusic.fillAmount = AudioManager.instance.VolumeMusic() * 2;
    }

    public void VolumeUpMusic()
    {
        AudioManager.instance.VolumeUpMusic();
        fillMusic.fillAmount = AudioManager.instance.VolumeMusic() * 2;
    }

    public void VolumeDownSFX()
    {
        AudioManager.instance.VolumeDownSFX();
        AudioManager.instance.PlaySound(volumeDown);
        fillSFX.fillAmount = AudioManager.instance.VolumeSFX();
    }

    public void VolumeUpSFX()
    {
        AudioManager.instance.VolumeUpSFX();
        AudioManager.instance.PlaySound(volumeUp);
        fillSFX.fillAmount = AudioManager.instance.VolumeSFX();
    }
}
