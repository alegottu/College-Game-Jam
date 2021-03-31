using UnityEngine;

public class FallingPlatform : Platform
{
    [SerializeField] private float timeToFall = 1;

    protected override void OnPlayerEnter()
    {
        
    }

    public void OnAnimationExit()
    {

    }

    protected override void OnPlayerExit()
    {
        return;
    }
}
