using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu (fileName = "ProductInfo", menuName = "Gameplay/ NewProduct")]
public class ProductInfo : ScriptableObject
{
    [PreviewField] [SerializeField] public Sprite Icon;

    [SerializeField] public string Title;

    [SerializeField] public string Description;

    [SerializeField] public BigNumber Price;

}
