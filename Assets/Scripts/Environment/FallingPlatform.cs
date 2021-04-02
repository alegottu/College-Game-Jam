using UnityEngine;

public class FallingPlatform : Platform
{
    [SerializeField] private Animator anim = null;
    [SerializeField] private Collider2D collider2d = null;
    [SerializeField] private float timeToFall = 1;
    [SerializeField] private float restoreCooldown = 1;

    private bool fall = false;
    private float fallTimer = 0;
    private float restoreTimer = 0;
    private Vector3 initial = Vector3.zero;

    private void Awake()
    {
        fallTimer = timeToFall;
        restoreTimer = restoreCooldown;
        initial = transform.position;
    }

    protected override void OnPlayerEnter()
    {
        fall = true;
        anim.SetTrigger("Fall");
    }

    private void Update()
    {
        if (restoreTimer <= 0)
        {
            transform.position = initial;
            restoreTimer = 0;
            collider2d.enabled = true;
            fall = false;
        }

        if (fallTimer <= 0)
        {
            collider2d.enabled = false;
        }

        if (fall)
        {
            anim.SetFloat("Timer", fallTimer);
            fallTimer -= Time.deltaTime;
            restoreTimer -= Time.deltaTime;
        }
    }

    protected override void OnPlayerExit()
    {
        return;
    }
}
