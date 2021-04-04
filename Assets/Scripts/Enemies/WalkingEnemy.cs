using UnityEngine;

public class WalkingEnemy : Enemy
{
    [SerializeField] private Transform[] points = null;

    private int targetPoint = 1;

    private void Awake()
    {
        direction = Vector3.left; // Matches sprite
    }

    protected override void FixedUpdate()
    {
        if (Mathf.Approximately(transform.position.x,  points[targetPoint].position.x))
        {
            targetPoint = targetPoint == points.Length - 1 ? 0 : targetPoint + 1;
        }

        direction = Vector2.right * ((Vector2)points[targetPoint].position - (Vector2)transform.position).normalized;
        Move();
    }

    protected override void Attack()
    {
        base.Attack();
        player.TakeDamage(stats.damage);
    }
}
