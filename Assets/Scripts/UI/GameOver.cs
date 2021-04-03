using UnityEngine;

public class GameOver : SceneTransition
{
    [SerializeField] private AudioSource music = null;

    private void Awake()
    {
        AudioController.Instance.ChangeMusicTrack(music);
    }

    public void Retry()
    {
        SceneController.Instance.Reload();
    }

    public void Quit()
    {
        SceneController.Instance.Quit();
    }
}