using UnityEngine;

[CreateAssetMenu(
        fileName = "ChestConfig",
        menuName = "Chest/New BigChestConfig"
    )]
public class BigChestConfig : ChestConfig
{
    public override Chest InstatiateChest(MonoBehaviour context, IGameContext gameContext)
    {
        return new BigChest(this, context, gameContext);
    }

}
