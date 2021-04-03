using UnityEngine;

public class Sadness : Item
{
    [SerializeField] private float wallJumpForce = 1;
    [SerializeField] private LayerMask grabbable = new LayerMask();

    protected override void OnPickUp()
    {
        WallGrab wallGrab = player.gameObject.AddComponent<WallGrab>();
        wallGrab.SetUp(graphic, order);
        wallGrab.SetStats(wallJumpForce, grabbable);
    }
}
