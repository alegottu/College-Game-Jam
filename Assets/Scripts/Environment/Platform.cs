using UnityEngine;

public abstract class Platform : MonoBehaviour
{
    protected Player player = null;

    protected abstract void OnPlayerEnter();
    protected abstract void OnPlayerExit();

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            this.player = player;
            OnPlayerEnter();
        }
    }

    protected virtual void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.Equals(player.gameObject))
        {
            OnPlayerExit();
            player = null;
        }
    }
}
