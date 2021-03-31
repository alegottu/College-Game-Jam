using UnityEngine;
using System;

public class CheckPoint : MonoBehaviour
{
    public static event Action<CheckPoint> OnAnyCheckPointReached;

    [SerializeField] private CameraController cam = null;
    [SerializeField] private Guardian guardian = null;
    [SerializeField] private Friend friend = null;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player player))
        {
            if (player == guardian)
            {
                cam.ChangeTarget(friend.transform);
                friend.enabled = true;
            }
            else
            {
                cam.ChangeTarget(guardian.transform);
                guardian.enabled = true;
            }

            guardian.light2d.enabled = !guardian.light2d.enabled;
            player.enabled = false;
            OnAnyCheckPointReached?.Invoke(this);
        }
    }
}
