using System;
using UnityEngine;

[Serializable]
public class GetEffectComponent : IGetEffectComponent
{
    public IEffect Effect
    {
        get { return _effect; }
    }

    [SerializeReference] private IEffect _effect;
}
