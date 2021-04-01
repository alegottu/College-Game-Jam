using UnityEngine;

public class Door : SceneTransition
{
    [SerializeField] private string nextStage = string.Empty;
    [SerializeField] private Animator playerAnim = null;

    // Ensure trigger is small and centered
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.Equals(playerAnim.transform.parent.gameObject))
        {
            playerAnim.SetTrigger("Exit");
        }
    }

    public void OnAnimationExit()
    {
        SceneController.Instance.LoadLevel(nextStage);
    }
}
