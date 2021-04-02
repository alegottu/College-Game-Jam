using UnityEngine;

public class PlayerMedia : MonoBehaviour
{
    [SerializeField] private AudioSource sfx = null;
    [SerializeField] private Animator anim = null;
    [SerializeField] private SpriteRenderer sprite = null;
    [SerializeField] private Player player = null;

    private void OnEnable()
    {
        player.OnJump += OnJump;
        player.OnMove += OnMove;
        player.OnFall += OnFall;
        player.OnLanding += OnLanding;
        player.OnPlayerExit += OnExit;
    }

    private void OnExit()
    {
        // Set conditions for idle
        anim.SetBool("Grounded", true);
        anim.SetFloat("Movement", 0);
    }

    private void OnJump()
    {
        anim.SetTrigger("Jump");
        anim.SetBool("Grounded", false);
    }

    private void OnMove(float movement)
    {
        anim.SetFloat("Movement", Mathf.Abs(movement));

        if (movement != 0)
         sprite.flipX = movement < 0;
    }

    private void OnFall(float speed)
    {
        anim.SetFloat("Fall", speed);
    }

    private void OnLanding()
    {
        anim.SetBool("Grounded", true);
    }

    private void OnDisable()
    {
        player.OnJump -= OnJump;
        player.OnMove -= OnMove;
        player.OnFall -= OnFall;
        player.OnLanding -= OnLanding;
        player.OnPlayerExit -= OnExit;
    }
}
