using UnityEngine;

public class TutorialEvent : MonoBehaviour
{
    [SerializeField] private GameObject screen = null;

    private void OnEnable()
    {
        GameStateManager.OnGameStateChange += OnGameStateChangeEventHandler;
    }

    private void OnGameStateChangeEventHandler(GameStateManager.GameState previous, GameStateManager.GameState current)
    {
        if (previous.Equals(GameStateManager.GameState.RUNNING) && current.Equals(GameStateManager.GameState.RUNNING) && SceneController.Instance.currentLevel.Equals("Tutorial"))
        {
            screen.SetActive(true);
        }
    }

    private void Update()
    {
        if (screen.activeSelf && Input.anyKeyDown)
        {
            screen.SetActive(false);
            Destroy(this);
        }
    }

    private void OnDisable()
    {
        GameStateManager.OnGameStateChange -= OnGameStateChangeEventHandler;
    }
}
