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
        if (transform.position.Equals(points[targetPoint].position))
        {
            targetPoint = targetPoint == points.Length - 1 ? 0 : targetPoint + 1;
        }

        direction = Vector3.MoveTowards(transform.position, points[targetPoint].position, stats.speed).normalized;
        Move();
    }

    protected override void Attack()
    {
        base.Attack();
        player.TakeDamage(stats.damage);
    }
}
