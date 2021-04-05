using UnityEngine;

public class AudioController : Singleton<AudioController>
{
    [SerializeField] private AudioSource music = null;
    [SerializeField] private AudioSource sfx = null;

    private float musicVolume = 1;
    private float sfxVolume = 1;

    public void ChangeMasterVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    public void ChangeMusicVolume(float volume)
    {
        music.volume = volume;
        musicVolume = volume;
    }

    public void ChangeSFXVolume(float volume)
    {
        sfx.volume = volume;
        sfxVolume = volume;
    }

    public void ChangeMusicTrack(AudioSource track)
    {
        music = track;
        music.volume = musicVolume;
    }

    public void ChangeSFXTrack(AudioSource track)
    {
        sfx = track;
        sfx.volume = sfxVolume;
    }
}
