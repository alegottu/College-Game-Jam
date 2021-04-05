using UnityEngine;

public class AudioController : Singleton<AudioController>
{
    [SerializeField] private AudioSource source = null;
    [SerializeField] private AudioClip music = null;

    private LevelMusic levelMusic = null;
    private float sfxVolume = 1;

    public void ChangeMusicVolume(float volume)
    {
        source.volume = volume;
    }

    // Use to set any sfx audio source that enters
    public void ChangeSFXVolume(float volume)
    {
        sfxVolume = volume;
    }

    public void ChangeTrack(AudioClip track)
    {
        source.clip = track;
    }

    public bool IsPlaying()
    {
        return source.isPlaying;
    }

    public void SetLoop(bool loop)
    {
        source.loop = loop;
    }
}
