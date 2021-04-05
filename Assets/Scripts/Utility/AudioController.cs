using UnityEngine;

public class AudioController : Singleton<AudioController>
{
    [SerializeField] private AudioSource source = null;

    private LevelMusic levelMusic = null;
    private float sfxVolume = 1;

    private void OnEnable()
    {
        LevelMusic.OnAnyMusicEnter += OnAnyMusicEnterEventHandler;
    }

    private void OnAnyMusicEnterEventHandler(LevelMusic music)
    {
        levelMusic = music;
    }

    public void ToggleLevelMusic()
    {
        levelMusic.enabled = !levelMusic.enabled;
    }

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

    public void Play()
    {
        source.PlayOneShot(source.clip);
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
