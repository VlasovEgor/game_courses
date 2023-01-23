using System;

public interface IFightWithEnemyComponent
{
    event Action<FightWihtEnemyOperation> OnStarted;
    event Action<FightWihtEnemyOperation> OnFinished;
    event Action<FightWihtEnemyOperation> OnCanceled;

    bool IsFighting { get; }

    bool CanFight(FightWihtEnemyOperation operation);

    void StartFight(FightWihtEnemyOperation operation);

    void StopFight();

    void CancelFight();
}
