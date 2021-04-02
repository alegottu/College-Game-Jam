using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] protected GameObject graphicPrefab = null;

    protected Player player = null;
    protected GameObject graphic = null;

    protected abstract void OnPickUp();

    // Create visual representation on the player
    protected virtual void Awake()
    {
        GameObject newGraphic = Instantiate(graphicPrefab);
        newGraphic.transform.parent = gameObject.transform;
        graphic = newGraphic;
    }

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
