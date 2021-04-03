using UnityEngine;

public class Dash : PowerUp<Rigidbody2D>
{
    private PlayerInput input = null;
    private float speed = 1;
    private float duration = 1;
    private float cooldown = 1;

    private Vector2 direction = Vector2.zero;
    private bool dashing = false;
    private float dashTimer = 0;
    private float cooldownTimer = 0;

    public void SetStats(float speed, float duration, float cooldown)
    {
        this.speed = speed;
        this.duration = duration;
        this.cooldown = cooldown;

        affected = gameObject.GetComponent<Rigidbody2D>();
        input = gameObject.GetComponent<PlayerInput>();
    }

    private void FixedUpdate()
    {
        if (dashing && dashTimer <= duration)
        {
            affected.velocity = direction * speed;
        }
        else
        {
            dashTimer = 0;
            dashing = false;
        }
    }

    private void Update()
    {
        if (dashing)
        {
            dashTimer += Time.deltaTime;
        }

        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer <= 0 && input.dash)
        {
            dashing = true;
            cooldownTimer = cooldown;
            direction = Vector2.right * input.movement;
        }
    }
}
