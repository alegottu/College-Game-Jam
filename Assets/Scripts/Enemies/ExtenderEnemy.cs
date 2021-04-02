using UnityEngine;

public class ExtenderEnemy : Enemy
{
    [SerializeField] private PlayerInput input = null;

    protected override void Update()
    {
        attackTimer -= Time.deltaTime;

        if (input.jumpEnter)
        {
            // Attack animation should stretch this enemy upwards and change their hitbox to follow suit
            Attack();
        }
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);

        if (inRange)
        {
            player.TakeDamage(stats.damage);
        }
    }
}
