using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public abstract class PowerUp<Component> : MonoBehaviour
{
    protected int order = 0;
    protected Component affected = default;
    protected Vector2 playerSize = Vector2.zero;
    protected GameObject graphic = null;
    protected Light2D graphicLight = null;

    public virtual void SetUp(GameObject graphic, int order)
    {
        this.graphic = graphic;
        graphicLight = graphic.GetComponent<Light2D>();

        this.order = order;
        playerSize = gameObject.GetComponentInChildren<SpriteRenderer>().bounds.size;

        graphic.transform.position = gameObject.transform.position + new Vector3(-playerSize.x * 2 / (order + 1), playerSize.y);
        graphic.SetActive(true);
    }

    protected virtual void AnimateUse()
    {
        graphicLight.enabled = false;
    }

    protected virtual void AnimateRestore()
    {
        graphicLight.enabled = true;
    }
}
