using UnityEngine;

public class ShrinkingPlatform : MonoBehaviour
{
    [SerializeField] private PlayerInput input = null;
    [SerializeField] private Vector3 shrinkSize = Vector3.one;
    [SerializeField] private Vector3 growSize = Vector3.one;

    private bool shrunk = false;

    private void Update()
    {
        if (input.jumpEnter)
        {
            transform.localScale = shrunk ? growSize : shrinkSize;
            shrunk = !shrunk;
        }
    }
}
