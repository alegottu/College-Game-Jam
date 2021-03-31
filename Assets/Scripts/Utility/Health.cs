using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    public event Action OnDeath;

    [SerializeField] private int _health = 1;
    public int health { get { return _health; } }
    [SerializeField] private int _maxHealth = 1; // Serializable for convenience, should always be set to the same value as _health in the inspector.
    public int maxHealth { get { return _maxHealth; } }

    public void TakeDamage(int amount)
    {
        _health -= amount;

        if (_health <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        _health += amount;
        _health = _health > maxHealth ? maxHealth : _health; 
    }

    private void Die()
    {
        OnDeath?.Invoke();
    } 
}
