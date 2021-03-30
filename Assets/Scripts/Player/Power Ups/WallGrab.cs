using UnityEngine;

public class WallGrab : PowerUp<Rigidbody2D>
{
    private PlayerInput input = null;
    private float gravity = 1;

    private void Awake()
    {
        affected = gameObject.GetComponent<Rigidbody2D>();
        input = gameObject.GetComponent<PlayerInput>();
        gravity = affected.gravityScale;
    }

    private void Update()
    {
        if (input.grab)
        {
            affected.gravityScale = 0;
        }
        else
        {
            affected.gravityScale = gravity;
        }
    }
}
