using UnityEngine;
using TMPro;

public class UIEventListener : MonoBehaviour
{
    [SerializeField] private GameObject tooltip = null;
    [SerializeField] private TextMeshProUGUI tooltipText = null;
    [SerializeField] private string tooltipEnd = string.Empty;

    private void OnEnable()
    {
        Item.OnAnyItemPickUp += OnAnyItemPickupEventHandelr;
    }

    private void OnAnyItemPickupEventHandelr(string message, KeyCode binding)
    {
        tooltipText.text = message.Replace("{}", binding.ToString()) + tooltipEnd;
        tooltip.SetActive(true);
    }

    private void OnDisable()
    {
        Item.OnAnyItemPickUp += OnAnyItemPickupEventHandelr;
    }
}
