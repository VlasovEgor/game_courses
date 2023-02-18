using UnityEngine;

public abstract class TimeShiftObserver : MonoBehaviour,
    IConstructListener,
    IStartGameListener,
    IFinishGameListener
{
    private TimeShiftEmitter _emitter;

    public virtual void Construct(GameContext context)
    {
        _emitter = context.GetService<TimeShiftEmitter>();
    }

    public void OnStartGame()
    {
        _emitter.OnTimeShifted += OnTimeShifted;
    }

    public void OnFinishGame()
    {
        _emitter.OnTimeShifted -= OnTimeShifted;
    }

    protected abstract void OnTimeShifted(TimeShiftReason reason, float shiftSeconds);
}