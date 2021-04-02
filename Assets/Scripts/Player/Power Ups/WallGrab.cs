using UnityEngine;

public class WallGrab : PowerUp<Rigidbody2D>
{
    private PlayerInput input = null;
    private LayerMask grabbable;
    private Vector2 playerSize = Vector2.zero;
    private RaycastHit2D wallHit = new RaycastHit2D();

    public void SetUp(GameObject graphic, LayerMask grabbable)
    {
        SetGraphic(graphic);
        affected = gameObject.GetComponent<Rigidbody2D>();
        input = gameObject.GetComponent<PlayerInput>();
        this.grabbable = grabbable;
        playerSize = gameObject.GetComponentInChildren<SpriteRenderer>().bounds.size;
    }

    private void Update()
    {
        wallHit = Physics2D.BoxCast(new Vector2(transform.position.x + playerSize.x / 2, transform.position.y), playerSize, 0f, new Vector2(input.movement, 0).normalized, playerSize.x, grabbable);
        Vector2 velocity = affected.velocity;

        if (input.grab && wallHit)
        {
            affected.velocity = new Vector2(affected.velocity.x, 0);
            AnimateUse();
        }
        else
        {
            affected.velocity = velocity;
            AnimateRestore();
        }
    }
}
