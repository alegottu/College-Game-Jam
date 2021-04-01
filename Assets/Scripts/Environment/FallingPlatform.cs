using UnityEngine;

public class FallingPlatform : Platform
{
    [SerializeField] private Collider2D collider2d = null;
    [SerializeField] private float timeToFall = 1;
    [SerializeField] private float fallSpeed = 1;
    [SerializeField] private float restoreCooldown = 1;

    private bool fall = false;
    private bool falling = false;
    private float fallTimer = 0;
    private float restoreTimer = 0;
    private Vector3 initial = Vector3.zero;

    private void Awake()
    {
        initial = transform.position;
    }

    protected override void OnPlayerEnter()
    {
        fall = true;
    }

    private void Update()
    {
        if (restoreTimer >= restoreCooldown)
        {
            transform.position = initial;
            fallTimer = 0;
            restoreTimer = 0;
            collider2d.enabled = true;
            fall = false;
            falling = false;
        }

        if (fallTimer >= timeToFall)
        {
            falling = true;
            collider2d.enabled = false;
            restoreTimer += Time.deltaTime;
            return;
        }

        if (fall)
        {
            fallTimer += Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (falling)
        {
            fallSpeed += Physics2D.gravity.y;
            transform.position += Vector3.down * fallSpeed * Time.deltaTime;
        }
    }

    protected override void OnPlayerExit()
    {
        return;
    }
}
