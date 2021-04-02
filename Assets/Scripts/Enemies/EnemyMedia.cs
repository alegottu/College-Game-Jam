using UnityEngine;

public class EnemyMedia : MonoBehaviour
{
    [SerializeField] private AudioSource audio = null;
    [SerializeField] private Animator anim = null;
    [SerializeField] private Enemy enemy = null;

    public void OnAttack()
    {
        anim.SetTrigger("Attack");
    }
}
