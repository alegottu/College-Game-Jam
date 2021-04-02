using UnityEngine;

public class FallingPlatform : Platform
{
    [SerializeField] private Animator anim = null;
    [SerializeField] private float timeToFall = 1;
    [SerializeField] private float restoreCooldown = 1;

    private bool fall = false;
    private float fallTimer = 0;
    private float restoreTimer = 0;

    private void Awake()
    {
        fallTimer = timeToFall;
        restoreTimer = restoreCooldown;
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
            anim.SetTrigger("Restore");
            restoreTimer = restoreCooldown;
            fall = false;
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
