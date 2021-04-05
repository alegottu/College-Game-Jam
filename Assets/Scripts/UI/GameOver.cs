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

    // Make sure to fulfill remaining events in the inspector
    public void Retry()
    {
        AudioController.Instance.ToggleLevelMusic();
        levelManager.Reset();
    }

    public void Quit()
    {
        SceneController.Instance.Quit();
    }
}
