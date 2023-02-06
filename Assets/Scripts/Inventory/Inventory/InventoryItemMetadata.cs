
using Sirenix.OdinInspector;
using System;
using UnityEngine;

[Serializable]
public class InventoryItemMetadata
{
    [SerializeField] public string Title;

    [TextArea]
    [SerializeField] public string Description;

    [PreviewField]
    [SerializeField]
    public Sprite Icon;
}

