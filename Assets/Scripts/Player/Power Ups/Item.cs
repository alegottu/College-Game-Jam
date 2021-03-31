using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected Player player = null;

    protected abstract void OnPickUp();

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Friend player))
        {
            this.player = player;
            OnPickUp();
            Destroy(gameObject);
        }
    }
}
