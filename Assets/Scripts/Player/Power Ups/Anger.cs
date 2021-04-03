using UnityEngine;

public class Anger : Item
{
    [SerializeField] private float dashSpeed = 1;
    [SerializeField] private float dashDuration = 1;
    [SerializeField] private float cooldown = 1;

    protected override void OnPickUp()
    {
        Dash dash = player.gameObject.AddComponent<Dash>();
        dash.SetUp(graphic, order);
        dash.SetStats(dashSpeed, dashDuration, cooldown);
    }
}
