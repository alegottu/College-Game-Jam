using UnityEngine;
using System;

public abstract class Enemy : MonoBehaviour
{
    public event Action OnAttack;
    public event Action<float> OnMove;
    public Health player = null; // change to fulfill through an event

    [SerializeField] protected EnemyStats stats = null;
    [SerializeField] protected SpriteRenderer sprite = null;
    [SerializeField] protected int difficultyMultiplier = 1;

    protected Vector3 direction = Vector3.right;
    protected float attackTimer = 0;
    protected bool inRange = false;

    protected virtual void Update()
    {
        attackTimer -= Time.deltaTime;

        if (attackTimer <= 0 && inRange)
        {
            Attack();
        }
    }

    protected virtual void FixedUpdate()
    {
        if (stats.speed == 0)
        {
            return;
        }

        ChangeDirection();
        Move();
    }

    protected virtual void ChangeDirection()
    {
        if (player)
        {
            direction = (player.transform.position - transform.position).normalized;
        }
        else
        {
            direction = Vector3.zero;
        }
    }

    protected virtual void Move()
    {
        OnMove?.Invoke(direction.x);
        transform.position += new Vector3(direction.x, direction.y, 0) * stats.speed * Time.deltaTime;
    }

    public void SetDirection(Vector3 direction)
    {
        this.direction = direction;
    }

    protected void StartAttack()
    {
        OnAttack?.Invoke();
        attackTimer = stats.attackSpeed;
    }

    protected virtual void Attack()
    {
        StartAttack();
    }

    // Default method for melee enemies; override completely for different cases
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.Equals(player.gameObject))
        {
            inRange = true;
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.Equals(player.gameObject))
        {
            inRange = false;
        }
    }
}
