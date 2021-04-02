using UnityEngine;

public class Sadness : Item
{
    [SerializeField] private LayerMask grabbable = new LayerMask();

    protected override void OnPickUp()
    {
        WallGrab wallGrab = player.gameObject.AddComponent<WallGrab>();
        wallGrab.SetUp(graphic, grabbable);
    }
}
