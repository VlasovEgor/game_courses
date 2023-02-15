using UnityEngine;


[CreateAssetMenu(
        fileName = "ChestConfig",
        menuName = "Chest/New MiddleChestConfig"
    )]
public class MiddleChestConfig : ChestConfig
{
    public override Chest InstatiateChest(MonoBehaviour context, IGameContext gameContext)
    {
        return new MiddleChest(this, context, gameContext);
    }
}
