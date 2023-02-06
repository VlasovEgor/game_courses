using UnityEngine;

public abstract class EffectHandler : MonoBehaviour
{
    public abstract void OnEffectAdded(IEffect effect);

    public abstract void OnEffectRemoved(IEffect effect);
}
