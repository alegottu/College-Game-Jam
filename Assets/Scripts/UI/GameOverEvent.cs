using UnityEngine;

public class GameOverEvent : SceneTransition
{
    private Health player = null;

    protected override void OnEnable()
    {
        base.OnEnable();
        Player.OnPlayerEnter += OnPlayerEnterEventHandler;
    }

    private void OnPlayerEnterEventHandler(Player player)
    {
        if (player.gameObject.TryGetComponent(out Health health))
        {
            health.OnDeath += OnPlayerDeathEventHandler;
        }
    }

    private void OnPlayerDeathEventHandler()
    {
        SceneController.Instance.LoadLevel("GameOver");
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        Player.OnPlayerEnter -= OnPlayerEnterEventHandler;

        if (player)
            player.OnDeath -= OnPlayerDeathEventHandler;
    }
}
