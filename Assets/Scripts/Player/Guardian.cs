using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using System.Collections.Generic;

public class Guardian : Player
{
    public Light2D light2d = null;

    [SerializeField] private GameObject emotionItem = null;
    [SerializeField] private GameObject lightPrefab = null;
    [SerializeField] private int lightAmount = 3;

    private bool itemUsed = false;
    private int lightsUsed = 0;
    private List<GameObject> currentLights = new List<GameObject>(); // Keeps track of the lights used since the last checkpoint reached

    private void OnEnable()
    {
        CheckPoint.OnAnyCheckPointReached += OnAnyCheckPointReachedEventHandler;
    }

    protected override void Update()
    {
        base.Update();

        if (lightsUsed < lightAmount && input.primary )
        {
            lightsUsed++;
            GameObject newLight = Instantiate(lightPrefab, transform.position, Quaternion.identity);
        }

        if (!itemUsed && emotionItem && input.secondary)
        {
            itemUsed = true;
            GameObject emotion = Instantiate(emotionItem, transform.position, Quaternion.identity);
        }
    }

    private void OnAnyCheckPointReachedEventHandler(CheckPoint _)
    {
        if (itemUsed)
        {
            emotionItem = null;
        }

        itemUsed = false;
        lightsUsed = 0;
        currentLights = new List<GameObject>();
    }

    public void Reset()
    {
        itemUsed = false;
        lightsUsed = 0;

        foreach (GameObject light in currentLights)
        {
            Destroy(light);
        }
        currentLights = new List<GameObject>();

        light2d.enabled = true;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        CheckPoint.OnAnyCheckPointReached -= OnAnyCheckPointReachedEventHandler;
    }
}
