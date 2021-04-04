using UnityEngine;

public class Parry : PowerUp<Rigidbody2D>
{
    private PlayerInput input = null;
    private float force = 1;
    private float duration = 1;
    private LayerMask enemy = new LayerMask();
    private RaycastHit2D parryHit = new RaycastHit2D();

    private bool parried = false;
    private float parryTimer = 0;

    public void SetStats(float force, float duration, LayerMask enemy)
    {
        this.force = force;
        this.duration = duration;
        this.enemy = enemy;

        input = gameObject.GetComponent<PlayerInput>();
        affected = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        parryHit = Physics2D.CircleCast(transform.position, playerSize.y, Vector2.down, playerSize.y, enemy);

        if (!parried && parryHit && input.primary)
        {
            parried = true;
        }

        if (parried && parryTimer <= duration)
        {
            affected.velocity = new Vector2(parryHit.normal.x * force, force);
        }
    }

    private void Update()
    {
        if (parried)
        {
            parryTimer += Time.deltaTime;
        }

        if (parryTimer > duration)
        {
            parried = false;
            parryTimer = 0;
        }
    }
}
