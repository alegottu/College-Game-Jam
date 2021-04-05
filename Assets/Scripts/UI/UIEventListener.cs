using UnityEngine;
using TMPro;

public class UIEventListener : MonoBehaviour
{
    [SerializeField] private GameObject tooltip = null;
    [SerializeField] private TextMeshProUGUI tooltipText = null;
    [SerializeField] private string tooltipEnd = string.Empty;

    private void OnEnable()
    {
        Item.OnAnyItemPickUp += OnAnyItemPickupEventHandler;
    }

    private void OnAnyItemPickupEventHandler(Item item)
    {
        tooltipText.text = item.message.Replace("{}", InputManager.Instance.ReadBinding(item.containedAbility).ToString()) + tooltipEnd;
        tooltip.SetActive(true);
    }

    private void OnDisable()
    {
        Item.OnAnyItemPickUp += OnAnyItemPickupEventHandler;
    }
}
