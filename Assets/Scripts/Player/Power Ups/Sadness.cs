using UnityEngine;

public class Sadness : Item
{
    protected override void OnPickUp()
    {
        player.gameObject.AddComponent<WallGrab>();
    }
}
