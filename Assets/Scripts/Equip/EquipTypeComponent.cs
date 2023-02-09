using System;
using UnityEngine;

[Serializable]
public class EquipTypeComponent : IEquipTypeComponent
{
    public EquipType Type
    {
        get { return _type; }
        set { _type = value; }
    }

    [SerializeField]
    private EquipType _type;
}
