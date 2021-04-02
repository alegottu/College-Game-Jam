using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Guardian : Player
{
    public Light2D light2d = null;

    [SerializeField] private GameObject emotionItem = null;
    [SerializeField] private GameObject lightPrefab = null;
    [SerializeField] private int lightAmount = 3;

    private int lightsUsed = 0;

    protected override void OnEnable()
    {
        base.OnEnable();
        CheckPoint.OnAnyCheckPointReached += OnAnyCheckPointReachedEventHandler;
    }

    protected override void Update()
    {
        base.Update();

        if (lightsUsed < lightAmount && input.attack )
        {
            lightsUsed++;
            GameObject newLight = Instantiate(lightPrefab, transform.position, Quaternion.identity);
        }

        if (emotionItem != null && input.grab)
        {
            GameObject emotion = Instantiate(emotionItem, transform.position, Quaternion.identity);
            emotionItem = null;
        }
    }

    private void OnAnyCheckPointReachedEventHandler(CheckPoint _)
    {
        lightsUsed = 0;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        CheckPoint.OnAnyCheckPointReached -= OnAnyCheckPointReachedEventHandler;
    }
}
