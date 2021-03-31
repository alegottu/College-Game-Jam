using UnityEngine;

public abstract class Platform : MonoBehaviour
{
    protected bool active = false;
    protected Player player = null;

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            active = true;
            this.player = player;
        }
    }

    protected virtual void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.Equals(player.gameObject))
        {
            active = false;
            this.player = null;
        }
    }
}
