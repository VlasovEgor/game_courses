using UnityEngine;
using Zenject;

public sealed class RealtimeSynchronizer : MonoBehaviour,  
        IAppStartListener,
        IAppStopListener,
        IGameLoadDataListener
{
    [Inject] private RealtimeManager _realtimeManager;

    private TimeShiftEmitter _timeShiftEmitter;

    public void OnLoadData(GameContext gameContext)
    {
        _timeShiftEmitter = gameContext.GetService<TimeShiftEmitter>();
    }

    void IAppStartListener.Start()
    {
        _realtimeManager.OnStarted += OnSessionStarted;
        _realtimeManager.OnResumed += OnSessionResumed;
    }

    void IAppStopListener.Stop()
    {
        _realtimeManager.OnStarted -= OnSessionStarted;
        _realtimeManager.OnResumed -= OnSessionResumed;
    }

    private void OnSessionStarted(long pauseSeconds)
    {
        Debug.Log($"On Session Started {pauseSeconds}");
        if (pauseSeconds > 0)
        {
            _timeShiftEmitter.EmitEvent(TimeShiftReason.START_GAME, pauseSeconds);
        }
    }

    private void OnSessionResumed(long pauseSeconds)
    {
        if (pauseSeconds > 0)
        {
            _timeShiftEmitter.EmitEvent(TimeShiftReason.RESUME_GAME, pauseSeconds);
        }
    }
}
