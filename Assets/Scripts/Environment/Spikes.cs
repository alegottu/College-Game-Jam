using UnityEngine;

public class Spikes : Platform
{
    protected override void OnPlayerEnter()
    {
        if (player.gameObject.TryGetComponent(out Health health))
        {
            health.Die();
        }
    }

    protected override void OnPlayerExit()
    {
        // Control animation
    }
}
