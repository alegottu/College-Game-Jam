using UnityEngine;
using System;

public abstract class Player : MonoBehaviour
{
    public static event Action<Player> OnPlayerEnter;
    public event Action<float> OnMove, OnFall;
    public event Action OnPlayerExit, OnJump, OnLanding;

    [HideInInspector] public float speedMultiplier = 1;
    [HideInInspector] public float damageMultipier = 1;

    [SerializeField] protected PlayerStats stats = null;
    [SerializeField] protected PlayerInput input = null;
    [SerializeField] protected Rigidbody2D rb = null;
    [SerializeField] protected SpriteRenderer character = null;
    [SerializeField] protected AudioSource sfx = null;

    protected bool grounded = true;
    protected bool canJump = true;

    protected virtual void Awake()
    {
        OnPlayerEnter?.Invoke(this);
        AudioController.Instance.ChangeSFXTrack(sfx);
    }

    protected virtual void Update()
    {
        if (input.jumpExit)
        {
            canJump = true;
        }
    }

    protected virtual void FixedUpdate()
    {
        OnMove?.Invoke(Mathf.Abs(input.movement));
        Move();

        if (canJump && grounded && input.jump)
        {
            OnJump?.Invoke();
            Jump();
        }

        if (rb.velocity.y <= stats.maxVelocity || !input.jump)
        {
            OnFall?.Invoke(rb.velocity.y);
            Fall();
        }
    }

    protected void Move()
    {
        transform.position += Vector3.right * input.movement * stats.speed * speedMultiplier * Time.deltaTime;
        character.flipX = input.movement < 0;
    }

    protected void Jump()
    {
        grounded = false;
        canJump = false;
        rb.velocity = Vector2.up * stats.jumpForce;
    }

    protected void Fall()
    {
        rb.velocity += Vector2.up * Physics2D.gravity.y * (stats.fallForce - 1) * Time.deltaTime;
    }

    protected virtual void OnCollisionEnter2D()
    {
        OnLanding?.Invoke();
        grounded = true;
    }

    public bool IsGrounded()
    {
        return grounded;
    }

    protected virtual void OnDisable()
    {
        OnPlayerExit?.Invoke();
    }
}
