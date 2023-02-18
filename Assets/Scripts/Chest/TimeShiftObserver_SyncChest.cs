
using UnityEngine;

public class TimeShiftObserver_SyncChest : MonoBehaviour,  IConstructListener,
    IStartGameListener,
    IFinishGameListener
{
    private ChestManager _chestManager;
    private TimeShiftEmitter _emitter;

    public virtual void Construct(GameContext context)
    {
        _emitter = context.GetService<TimeShiftEmitter>();
        _chestManager = context.GetService<ChestManager>();
    }

    public void OnStartGame()
    {
        _emitter.OnTimeShifted += OnTimeShifted;
    }

    public void OnFinishGame()
    {
        _emitter.OnTimeShifted -= OnTimeShifted;
    }

    protected void OnTimeShifted(TimeShiftReason reason, float shiftSeconds)
    {
        SyncChests(shiftSeconds);
    }

    private void SyncChests(float shiftSeconds)
    {
        var chests = _chestManager.GetActiveChests();
        for (int i = 0, count = chests.Count; i < count; i++)
        {
            var chest = chests[i];
            chest.RemainingSeconds -= shiftSeconds;
        }
    }
}
