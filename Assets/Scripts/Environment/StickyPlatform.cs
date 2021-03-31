using UnityEngine;

public class StickyPlatform : Platform
{
    [SerializeField] private float slowAmount = 0; // Should be a number above 0.25 and below 0.75

    protected override void OnPlayerEnter()
    {
        player.speedMultiplier -= slowAmount;
    }

    protected override void OnPlayerExit()
    {
        player.speedMultiplier += slowAmount;
    }
}
