#if UNITY_EDITOR
using UnityEngine;


[CreateAssetMenu(
    fileName = "BlackboardKeysConfig",
    menuName = "AI/Blackboards/BlackboardKeysConfig"
)]
public sealed class BlackboardKeysConfig : ScriptableObject
{
    [SerializeField]
    public string[] names;

    public static BlackboardKeysConfig EditorInstance
    {
        get {
            return Resources.Load<BlackboardKeysConfig>("BlackboardKeysConfig"); }
    }
}

#endif