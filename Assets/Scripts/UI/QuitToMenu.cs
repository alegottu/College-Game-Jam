using UnityEngine;

public class QuitToMenu : SceneTransition, IMenuButton
{
    [SerializeField] private GameObject pauseMenu = null;

    public void OnClick()
    {
        pauseMenu.SetActive(false);
        SceneController.Instance.UnloadLevel();
        SceneController.Instance.LoadLevel("Menu");
    }
}
