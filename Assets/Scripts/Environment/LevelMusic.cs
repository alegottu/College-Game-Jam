using UnityEngine;

public class LevelMusic : MonoBehaviour
{
    // Assign the intro to the audio source in the inspector
    [SerializeField] private AudioClip loop = null;
    [SerializeField] private AudioClip intro = null;

    private void OnEnable()
    {
        AudioController.Instance.ChangeTrack(intro);
        AudioController.Instance.SetLoop(false);
    }

    private void Update()
    {
        if (!AudioController.Instance.IsPlaying())
        {
            AudioController.Instance.ChangeTrack(loop);
            AudioController.Instance.SetLoop(true);
        }
    }
}
