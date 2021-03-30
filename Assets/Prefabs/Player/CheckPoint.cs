using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private CameraController cam = null;
    [SerializeField] private Player characterToFollow = null;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player player))
        {
            cam.ChangeTarget(characterToFollow.transform);
            characterToFollow.enabled = true;
            player.enabled = false;
        }
    }
}
