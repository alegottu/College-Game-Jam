using UnityEngine;

[CreateAssetMenu(fileName = "New Player Stats", menuName = "Player Stats", order = 1)]
public class PlayerStats : ScriptableObject
{
    [SerializeField] private float _speed = 1;
    public float speed { get { return _speed; } }

    [SerializeField] private float _fallForce = 1;
    public float fallForce { get { return _fallForce; } }

    [SerializeField] private float _jumpForce = 1;
    public float jumpForce { get { return _jumpForce; } }

    [SerializeField] private float _maxVelocity = 0;
    public float maxVelocity { get { return _maxVelocity; } }
}
