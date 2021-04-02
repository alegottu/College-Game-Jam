using UnityEngine;
using System;

public class LevelManager : MonoBehaviour
{
    public static event Action<LevelManager> OnLevelStart;

    [SerializeField] private Friend friend = null;
    [SerializeField] private Guardian guardian = null;

    private CheckPoint previous = null;

    private void Awake()
    {
        OnLevelStart?.Invoke(this);
    }

    private void OnEnable()
    {
        CheckPoint.OnAnyCheckPointReached += OnAnyCheckPointReachedEventHandler;
    }

    private void OnAnyCheckPointReachedEventHandler(CheckPoint point)
    {
        previous = point;
    }

    public void Reset() // Return to last checkpoint reached
    {
        friend.transform.position = previous.transform.position;
        guardian.transform.position = previous.transform.position;
    }
}
