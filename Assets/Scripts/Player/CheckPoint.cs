using UnityEngine;
using System;

public class CheckPoint : MonoBehaviour
{
    public static event Action<CheckPoint> OnAnyCheckPointReached;

    [SerializeField] private bool isLast = false;
    [SerializeField] private CameraController cam = null;
    [SerializeField] private Guardian guardian = null;
    [SerializeField] private Friend friend = null;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player player))
        {
            OnAnyCheckPointReached?.Invoke(this);

            if (player.Equals(friend))
            {
                friend.enabled = false;
                cam.ChangeTarget(guardian.transform);
                guardian.enabled = true;
                guardian.light2d.enabled = true;
                gameObject.SetActive(false);
            }
            else
            {
                guardian.light2d.enabled = false;
                guardian.enabled = false;
                cam.ChangeTarget(friend.transform);
                friend.enabled = true;

                if (isLast)
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
