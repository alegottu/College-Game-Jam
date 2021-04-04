using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameStateManager gameState = null;
    [SerializeField] private GameObject pauseMenu = null;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameState.TogglePause();
            pauseMenu.SetActive(true);
        }
    }
}
