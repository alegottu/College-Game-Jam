using UnityEngine;

public class ProjectileEnemy : Enemy
{
    [SerializeField] private GameObject projectile = null;
    [SerializeField] private Transform shootPoint = null;

    protected override void Attack()
    {
        base.Attack();
        GameObject newProjectile = Instantiate(projectile, shootPoint.position, Quaternion.identity);
    }
}
