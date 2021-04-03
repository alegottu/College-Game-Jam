using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] protected int order = 0;
    [SerializeField] protected GameObject graphicPrefab = null;

    protected Player player = null;
    protected GameObject graphic = null;

    protected abstract void OnPickUp();

    // Create visual representation for the player
    protected virtual void Awake()
    {
        GameObject newGraphic = Instantiate(graphicPrefab);
        newGraphic.SetActive(false);
        graphic = newGraphic;
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Friend player))
        {
            this.player = player;
            graphic.transform.parent = player.transform; 
            OnPickUp();
            Destroy(gameObject);
        }
    }
}
