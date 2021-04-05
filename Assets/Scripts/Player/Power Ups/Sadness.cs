using UnityEngine;

public class Sadness : Item
{
    [SerializeField] private Vector2 wallJumpForce = Vector2.one;
    [SerializeField] private float wallJumpTime = 1;
    [SerializeField] private LayerMask grabbable = new LayerMask();

    protected override void OnPickUp()
    {
        WallGrab wallGrab = player.gameObject.AddComponent<WallGrab>();
        wallGrab.SetUp(graphic, order);
        wallGrab.SetStats(wallJumpForce, wallJumpTime, grabbable);
    }
}
