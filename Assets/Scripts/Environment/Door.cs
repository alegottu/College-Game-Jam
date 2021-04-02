using UnityEngine;

public class Door : SceneTransition
{
    [SerializeField] private string nextStage = string.Empty;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Friend _))
        {
            SceneController.Instance.LoadLevel(nextStage);
        }
    }
}
