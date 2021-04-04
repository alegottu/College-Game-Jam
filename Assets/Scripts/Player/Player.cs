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
    [SerializeField] protected AudioSource sfx = null;
    [SerializeField] protected LayerMask ground = new LayerMask();

    protected RaycastHit2D groundHit = new RaycastHit2D();
    protected Vector2 playerSize = Vector2.zero;
    protected bool grounded = true;
    protected bool canJump = true;
    protected bool coyoteTime = false;
    protected float coyoteTimer = 0;

    protected virtual void Awake()
    {
        playerSize = gameObject.GetComponentInChildren<SpriteRenderer>().bounds.size;
    }

    protected virtual void OnEnable()
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

        if (coyoteTime)
        {
            coyoteTimer += Time.deltaTime;

            if (coyoteTimer >= stats.coyoteTime)
            {
                grounded = false;
                coyoteTime = false;
                coyoteTimer = 0;
            }
        }
    }

    protected virtual void FixedUpdate()
    {
        Move();
        CheckGround();

        if (canJump && grounded && input.jump)
        {
            Jump();
        }

        if (rb.velocity.y <= stats.maxVelocity || !input.jump)
        {
            Fall();
        }
    }

    protected void Move()
    {
        OnMove?.Invoke(input.movement);
        transform.position += Vector3.right * input.movement * stats.speed * speedMultiplier * Time.deltaTime;
    }

    protected void CheckGround()
    {
        groundHit = Physics2D.BoxCast(transform.position - new Vector3(0, playerSize.y / 2), new Vector2(playerSize.x / 2, 0.5f), 0f, Vector2.down, 0.5f, ground);

        if (groundHit)
        {
            OnLanding?.Invoke();
            grounded = true;
        }
        else
        {
            coyoteTime = true;
        }
    }

    protected void Jump()
    {
        OnJump?.Invoke();
        grounded = false;
        canJump = false;
        rb.velocity = Vector2.up * stats.jumpForce;
    }

    protected void Fall()
    {
        OnFall?.Invoke(rb.velocity.y);
        rb.velocity += Vector2.up * Physics2D.gravity.y * (stats.fallForce - 1) * Time.deltaTime;
    }

    protected virtual void OnDisable()
    {
        OnPlayerExit?.Invoke();
    }
}
