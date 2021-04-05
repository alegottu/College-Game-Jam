using UnityEngine;
using Cinemachine;
using System;

public class CameraController : MonoBehaviour
{
    public static event Action<CameraController> OnNewCameraActive;

    [SerializeField] private CinemachineVirtualCamera vcam = null;

    private void Awake()
    {
        OnNewCameraActive?.Invoke(this);
    }

    public void ChangeTarget(Transform target)
    {
        vcam.Follow = target;
    }
}
