using UnityEngine;

public class EnemyMedia : MonoBehaviour
{
    [SerializeField] private AudioSource sfx = null;
    [SerializeField] private Animator anim = null;
    [SerializeField] private SpriteRenderer sprite = null;
    [SerializeField] private Enemy enemy = null;

    private void OnEnable()
    {
        enemy.OnAttack += OnAttack;
        enemy.OnMove += OnMove;
    }

    private void OnAttack()
    {
        anim.SetTrigger("Attack");
    }

    private void OnMove(float movement)
    {
        sprite.flipX = movement > 0;
    }

    private void OnDisable()
    {
        enemy.OnAttack -= OnAttack;
        enemy.OnMove -= OnMove;
    }
}
