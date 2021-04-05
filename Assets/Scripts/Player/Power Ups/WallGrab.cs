using UnityEngine;

public class WallGrab : PowerUp<Rigidbody2D>
{
    private PlayerInput input = null;
    private Animator playerAnim = null;
    private Vector2 jumpForce = Vector2.zero;
    private float jumpTime = 0;
    private LayerMask grabbable;

    private RaycastHit2D wallHit = new RaycastHit2D();
    private bool grabbing = false;
    private bool jumping = false;
    private float jumpTimer = 0;

    public void SetStats(Vector2 jumpForce, float jumpTime, LayerMask grabbable)
    {
        this.jumpForce = jumpForce;
        this.jumpTime = jumpTime;
        this.grabbable = grabbable;

        affected = gameObject.GetComponent<Rigidbody2D>();
        input = gameObject.GetComponent<PlayerInput>();
        playerAnim = gameObject.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        wallHit = Physics2D.BoxCast(new Vector2(transform.position.x + playerSize.x / 2 * Mathf.Round(input.movement), transform.position.y), new Vector2(0.01f, playerSize.y / 2), 0f, (Vector2.right * input.movement).normalized, 0, grabbable);

        if (input.grab && wallHit)
        {
            grabbing = true;
            affected.velocity = new Vector2(affected.velocity.x, 0);

            if (input.jump && jumpTimer < jumpTime)
            {
                jumping = true;
                affected.velocity = new Vector2(-input.movement * jumpForce.x, jumpForce.y);
            }
        }
        else
        {
            grabbing = false;
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

        if (jumping)
        {
            jumpTimer += Time.deltaTime;
        }

        if (input.jumpExit)
        {
            jumpTimer = 0;
            jumping = false;
        }
    }
}
