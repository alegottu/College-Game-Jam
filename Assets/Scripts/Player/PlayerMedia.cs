using UnityEngine;

public class PlayerMedia : MonoBehaviour
{
    [SerializeField] private AudioSource audio = null;
    [SerializeField] private Animator anim = null;
    [SerializeField] private SpriteRenderer sprite = null;
    [SerializeField] private Player player = null;

    private void OnEnable()
    {
        player.OnJump += OnJump;
        player.OnMove += OnMove;
        player.OnFall += OnFall;
        player.OnLanding += OnLanding;
    }

    private void OnJump()
    {
        anim.SetTrigger("Jump");
        anim.SetBool("Grounded", false);
    }

    private void OnMove(float movement)
    {
        anim.SetFloat("Movement", movement);
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
    }
}
