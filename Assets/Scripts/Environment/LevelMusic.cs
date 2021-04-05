using UnityEngine;
using System;

public class LevelMusic : MonoBehaviour
{
    public static event Action<LevelMusic> OnAnyMusicEnter;

    // Assign the intro to the audio source in the inspector
    [SerializeField] private AudioClip loop = null;
    [SerializeField] private AudioClip intro = null;

    private void Awake()
    {
        OnAnyMusicEnter?.Invoke(this);
    }

    private void OnEnable()
    {
        AudioController.Instance.ChangeTrack(intro);
        AudioController.Instance.SetLoop(false);
        AudioController.Instance.Play();
    }

    private void Update()
    {
        if (!AudioController.Instance.IsPlaying())
        {
            AudioController.Instance.ChangeTrack(loop);
            AudioController.Instance.SetLoop(true);
            AudioController.Instance.Play();
        }
    }
}
