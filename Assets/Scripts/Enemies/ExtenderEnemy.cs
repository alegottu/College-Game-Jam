using UnityEngine;

public class ExtenderEnemy : Enemy
{
    [SerializeField] private PlayerInput input = null;

    protected override void Update()
    {
        attackTimer -= Time.deltaTime;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (input.jumpEnter)
        {
            // Attack animation should stretch this enemy upwards and change their hitbox to follow suit
            Attack();
        }
    }
}
