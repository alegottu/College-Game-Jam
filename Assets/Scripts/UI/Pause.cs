using UnityEngine;

public class Pause : MonoBehaviour, IMenuButton
{
    [SerializeField] private GameStateManager gameState = null;
    [SerializeField] private GameObject pauseMenu = null;

    private void Update()
    {
        if (!pauseMenu.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            gameState.TogglePause();
            pauseMenu.SetActive(true);
        }
    }

    public void OnClick()
    {
        gameState.TogglePause();
        pauseMenu.SetActive(false);
    }
}
