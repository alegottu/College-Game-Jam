using UnityEngine;

public class Spikes : Platform
{
    protected override void OnPlayerEnter()
    {
        player.GetComponent<Health>().Die();
    }

    protected override void OnPlayerExit()
    {
        // Control animation
    }
}
