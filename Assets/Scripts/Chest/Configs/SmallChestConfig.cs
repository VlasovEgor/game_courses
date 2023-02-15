using UnityEngine;

[CreateAssetMenu(
        fileName = "ChestConfig",
        menuName = "Chest/New SmallChestConfig"
    )]
public class SmallChestConfig : ChestConfig
{
    public override Chest InstatiateChest(MonoBehaviour context, IGameContext gameContext)
    {
        return new SmallChest(this, context, gameContext);
    }
}
