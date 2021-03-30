using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera vcam = null;

    public void ChangeTarget(Transform target)
    {
        vcam.Follow = target;
    }
}
