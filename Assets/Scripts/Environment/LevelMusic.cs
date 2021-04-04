using UnityEngine;

public class LevelMusic : MonoBehaviour
{
    // Assign the intro to the audio source in the inspector
    [SerializeField] private AudioClip loop = null;
    [SerializeField] private AudioSource music = null;

    private void Awake()
    {
        AudioController.Instance.ChangeMusicTrack(music);
    }

    private void Update()
    {
        if (!music.isPlaying)
        {
            music.PlayOneShot(loop);
            music.loop = true;
        }
    }
}
