using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public abstract class PowerUp<Component> : MonoBehaviour
{
    protected Component affected = default;
    protected GameObject graphic = null;
    protected Light2D graphicLight = null;

    public virtual void SetGraphic(GameObject graphic)
    {
        this.graphic = graphic;
        graphicLight = graphic.GetComponent<Light2D>();
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
