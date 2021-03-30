using UnityEngine;

public abstract class PowerUp<Component> : MonoBehaviour
{
    protected Component affected = default;
}
