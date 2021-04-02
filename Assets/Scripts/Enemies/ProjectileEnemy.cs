using UnityEngine;

public class ProjectileEnemy : Enemy
{
    [SerializeField] private GameObject projectile = null;
    [SerializeField] private Transform rotator = null;
    [SerializeField] private Transform shootPoint = null;

    public void OnAttackAnimated()
    {
        GameObject newProjectile = Instantiate(projectile, shootPoint.position, rotator.rotation);
    }
}
