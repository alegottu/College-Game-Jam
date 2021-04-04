using UnityEngine;

public class Parry : PowerUp<Rigidbody2D>
{
    private PlayerInput input = null;
    private float force = 1;
    private LayerMask enemy = new LayerMask();
    private RaycastHit2D parryHit = new RaycastHit2D();

    public void SetStats(float force, LayerMask enemy)
    {
        this.force = force;
        this.enemy = enemy;

        input = gameObject.GetComponent<PlayerInput>();
        affected = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        parryHit = Physics2D.CircleCast(transform.position, playerSize.y / 2, Vector2.zero, playerSize.y / 2, enemy);

        if (parryHit && input.primary)
        {
            affected.velocity = new Vector2(-parryHit.normal.x * force, force);
        }
    }
}
