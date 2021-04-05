using UnityEngine;
using System;

public class Door : MonoBehaviour
{
    [SerializeField] private string nextStage = string.Empty;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Friend _))
        {
            SceneController.Instance.LoadLevel(nextStage);
        }
    }
}
