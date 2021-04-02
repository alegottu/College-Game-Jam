using UnityEngine;

public class PlayerMedia : MonoBehaviour
{
    [SerializeField] private AudioSource audio = null;
    [SerializeField] private Animator anim = null;
    [SerializeField] private Player player = null;

    private void OnEnable()
    {
        player.OnJump += OnJump;
        player.OnMove += OnMove;
        player.OnFall += OnFall;
        player.OnLanding += OnLanding;
    }

    public void OnJump()
    {
        anim.SetTrigger("Jump");
        anim.SetBool("Grounded", false);
    }

    public void OnMove(float movement)
    {
        anim.SetFloat("Movement", movement);
    }

    public void OnFall(float speed)
    {
        anim.SetFloat("Fall", speed);
    }

    public void OnLanding()
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
