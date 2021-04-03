using UnityEngine;

public class ShrinkingPlatform : MonoBehaviour
{
    [SerializeField] private PlayerInput input = null;
    [SerializeField] private Animator anim = null;
    [SerializeField] private bool shrunk = false; // Serialized to be able to change the starting state

    private void Awake()
    {
        if (shrunk)
        {
            anim.SetTrigger("shrink");
        }
    }

    private void Update()
    {
        if (input.jumpEnter)
        {
            if (shrunk)
            {
                shrunk = false;
                anim.SetTrigger("Grow");
            }
            else
            {
                shrunk = true;
                anim.SetTrigger("Shrink");
            }
        }
    }
}
