using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private Friend friend = null;
    private Guardian guardian = null;

    private CheckPoint previous = null;

    private void OnEnable()
    {
        Player.OnPlayerEnter += OnPlayerEnterEventHandler;
        CheckPoint.OnAnyCheckPointReached += OnAnyCheckPointReachedEventHandler;
    }

    private void OnPlayerEnterEventHandler(Player player)
    {
        if (player is Friend)
        {
            friend = (Friend)player;
        }
        else if (player is Guardian)
        {
            guardian = (Guardian)player;
        }
    }

    private void OnAnyCheckPointReachedEventHandler(CheckPoint point)
    {
        previous = point;
    }

    public void Reset() // Return to last checkpoint reached
    {
        friend.transform.position = previous.transform.position;
        guardian.transform.position = previous.transform.position;
    }
}
