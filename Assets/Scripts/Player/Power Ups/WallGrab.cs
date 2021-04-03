﻿using UnityEngine;

public class WallGrab : PowerUp<Rigidbody2D>
{
    private PlayerInput input = null;
    private Animator playerAnim = null;
    private float wallJumpForce = 0;
    private LayerMask grabbable;

    private RaycastHit2D wallHit = new RaycastHit2D();
    private bool grabbing = false;

    public void SetStats(float wallJumpForce, LayerMask grabbable)
    {
        this.wallJumpForce = wallJumpForce;
        this.grabbable = grabbable;

        affected = gameObject.GetComponent<Rigidbody2D>();
        input = gameObject.GetComponent<PlayerInput>();
        playerAnim = gameObject.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        wallHit = Physics2D.BoxCast(new Vector2(transform.position.x + playerSize.x / 2, transform.position.y), playerSize, 0f, new Vector2(input.movement, 0).normalized, playerSize.x, grabbable);
        Vector2 velocity = affected.velocity;

        if (input.grab && wallHit)
        {
            grabbing = true;
            affected.velocity = new Vector2(affected.velocity.x, 0);

            if (input.jump && Mathf.Abs(Mathf.Round(input.movement) + wallHit.normal.x) > 0)
            {
                affected.velocity = new Vector2(affected.velocity.x, wallJumpForce);
            }
        }
        else
        {
            grabbing = false;
            affected.velocity = velocity;
        }
    }

    private void Update()
    {
        if (input.grabEnter)
        {
            playerAnim.SetTrigger("Grab");
        }

        if (grabbing)
        {
            AnimateUse();
        }
        else
        {
            AnimateRestore();
        }
    }
}
