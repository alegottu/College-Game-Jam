using UnityEngine;

public class Restart : MonoBehaviour, IMenuButton
{
    public void OnClick()
    {
        SceneController.Instance.UnloadLevel(SceneController.Instance.currentLevel);
        SceneController.Instance.LoadLevel(SceneController.Instance.currentLevel);
    }
}
