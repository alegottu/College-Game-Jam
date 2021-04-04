using UnityEngine;
using System;

public abstract class Item : MonoBehaviour
{
    public static event Action<string, KeyCode> OnAnyItemPickUp; // Sends message for UI to display

    [SerializeField] protected string message = string.Empty;
    [SerializeField] protected string abilityContained = string.Empty; // Ensure this matches up with the binding key in the Input Manager
    [SerializeField] protected int order = 0;
    [SerializeField] protected GameObject graphicPrefab = null;

    protected Player player = null;
    protected GameObject graphic = null;

    protected abstract void OnPickUp();

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Friend player))
        {
            // Create visual representation for the player
            GameObject newGraphic = Instantiate(graphicPrefab);
            newGraphic.SetActive(false);
            graphic = newGraphic;

            this.player = player;
            graphic.transform.parent = player.transform;
            OnPickUp();
            OnAnyItemPickUp?.Invoke(message, InputManager.Instance.ReadBinding(abilityContained));
            Destroy(gameObject);
        }
    }
}
