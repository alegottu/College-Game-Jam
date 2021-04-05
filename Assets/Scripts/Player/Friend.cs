using UnityEngine;

public class Friend : Player
{
    [SerializeField] private Health health;

    private Item currentItem = null; // To delete the item if it was obtained within this checkpoint

    private void OnEnable()
    {
        health.OnDeath += OnDeathEventHandler;
        CheckPoint.OnAnyCheckPointReached += OnAnyCheckPointReachedEventHandler;
        Item.OnAnyItemPickUp += OnAnyItemPickupEventHandler;
    }

    private void OnDeathEventHandler()
    {
        health.Heal(health.maxHealth);
    }

    private void OnAnyCheckPointReachedEventHandler(CheckPoint obj)
    {
        currentItem = null;
    }

    private void OnAnyItemPickupEventHandler(Item item)
    {
        currentItem = item;
    }

    public void Reset()
    {
        if (currentItem)
        {
            Destroy(currentItem);
        }
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        health.OnDeath -= OnDeathEventHandler;
        CheckPoint.OnAnyCheckPointReached -= OnAnyCheckPointReachedEventHandler;
        Item.OnAnyItemPickUp -= OnAnyItemPickupEventHandler;
    }
}
