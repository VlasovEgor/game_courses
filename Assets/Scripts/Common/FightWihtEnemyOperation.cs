public class FightWihtEnemyOperation
{
    public readonly IEntity TargetEnemy;
    public bool IsCompleted;

    public FightWihtEnemyOperation(IEntity targetEnemy)
    {
        TargetEnemy = targetEnemy;
    }
}