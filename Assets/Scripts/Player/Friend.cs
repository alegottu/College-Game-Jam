using UnityEngine;

public class Friend : Player
{
    [SerializeField] private Health health;

    protected override void OnEnable()
    {
        base.OnEnable();
        health.OnDeath += OnDeathEventHandler;
    }

    private void OnDeathEventHandler()
    {
        gameObject.SetActive(false);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        health.OnDeath -= OnDeathEventHandler;
    }
}
