using UnityEngine;

// Meant for use in OnClick events
public class GameOver : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager = null;
    [SerializeField] private AudioClip music = null;

    private void Awake()
    {
        AudioController.Instance.ChangeTrack(music);
    }

    public void Retry()
    {
        levelManager.Reset();
    }

    public void Quit()
    {
        SceneController.Instance.Quit();
    }
}
