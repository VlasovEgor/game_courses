using System;

public interface IFIghtWithEnemyComponent
{
    event Action<FightWihtEnemyOperation> OnStarted;
    event Action<FightWihtEnemyOperation> OnFinished;

    bool IsFighting { get; }

    bool CanFight(FightWihtEnemyOperation operation);

    void StartFight(FightWihtEnemyOperation operation);

    void Fight(int damage);

    void StopFight();

    void CanselFight();
}
