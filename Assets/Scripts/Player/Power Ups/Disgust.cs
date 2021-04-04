using UnityEngine;

public class Disgust : Item
{
    [SerializeField] private float parryForce = 1;
    [SerializeField] private float parryTime = 1;
    [SerializeField] private LayerMask enemy = new LayerMask();

    protected override void OnPickUp()
    {
        Parry parry = player.gameObject.AddComponent<Parry>();
        parry.SetUp(graphic, order);
        parry.SetStats(parryForce, parryTime, enemy);
    }
}
