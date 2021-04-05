using UnityEngine;

public class GameOverEvent : MonoBehaviour
{
    [SerializeField] private GameObject screen = null;
    [SerializeField] private AudioClip music = null;

    private Health player = null;

    private void OnEnable()
    {
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
        screen.SetActive(true);
    }

    private void OnDisable()
    {
        Player.OnPlayerEnter -= OnPlayerEnterEventHandler;

        if (player)
            player.OnDeath -= OnPlayerDeathEventHandler;
    }
}
