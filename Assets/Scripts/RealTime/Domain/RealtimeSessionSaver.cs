using Zenject;

public sealed class RealtimeSessionSaver :
    IAppStartListener,
    IAppStopListener
{

    [Inject] private RealtimeRepository _repository;

    [Inject] private RealtimeManager _realtimeManager;

    void IAppStartListener.Start()
    {
        _realtimeManager.OnPaused += SaveSession;
        _realtimeManager.OnEnded += SaveSession;
    }

    void IAppStopListener.Stop()
    {
        _realtimeManager.OnPaused -= SaveSession;
        _realtimeManager.OnEnded -= SaveSession;
    }

    private void SaveSession()
    {
        var data = new RealtimeData
        {
            NowSeconds = _realtimeManager.RealtimeSeconds
        };
        _repository.SaveSession(data);
    }
}