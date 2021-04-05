using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private Friend friend = null;
    private Guardian guardian = null;
    private CameraController activeCam = null;

    private CheckPoint current = null;
    private Vector2[] initialPos = new Vector2[2]; // order = guardian, friend
    private bool atStart = false;

    private void OnEnable()
    {
        Player.OnPlayerEnter += OnPlayerEnterEventHandler;
        CheckPoint.OnAnyCheckPointReached += OnAnyCheckPointReachedEventHandler;
        CameraController.OnNewCameraActive += OnNewCameraActiveEventHandler;
    }

    private void OnPlayerEnterEventHandler(Player player)
    {
        if (player is Friend)
        {
            friend = (Friend)player;
            initialPos[1] = player.transform.position;
        }
        else if (player is Guardian)
        {
            guardian = (Guardian)player;
            initialPos[0] = player.transform.position;
        }

        atStart = true;
    }

    private void OnAnyCheckPointReachedEventHandler(CheckPoint point)
    {
        current = point;

        if (point.Equals(current))
        {
            atStart = false;
        }
    }

    private void OnNewCameraActiveEventHandler(CameraController cam)
    {
        activeCam = cam;
    }

    public void Reset() // Return to last checkpoint reached
    {
        if (!atStart)
        {
            guardian.transform.position = current.transform.position;
            guardian.Reset();
            friend.transform.position = current.transform.position;
            friend.Reset();
        }
        else
        {
            guardian.transform.position = initialPos[0];
            guardian.light2d.enabled = true;
            friend.transform.position = initialPos[1];
        }

        activeCam.ChangeTarget(guardian.transform);
    }

    private void OnDisable()
    {
        Player.OnPlayerEnter -= OnPlayerEnterEventHandler;
        CheckPoint.OnAnyCheckPointReached -= OnAnyCheckPointReachedEventHandler;
        CameraController.OnNewCameraActive -= OnNewCameraActiveEventHandler;
    }
}
