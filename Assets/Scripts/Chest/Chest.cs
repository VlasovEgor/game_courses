using Elementary;
using System;
using UnityEngine;

public abstract class Chest
{
    public event Action<Chest> OnStarted;
    public event Action<Chest, float> OnTimeChanged;
    public event Action<Chest> OnCompleted;

    public string Id
    {
        get
        {
            return _config.Id;
        }
    }

    public bool IsActive
    {
        get
        {
            return _countdown.IsPlaying;
        }
    }

    public float RemainingSeconds
    {
        get
        {
            return _countdown.RemainingTime;
        }
        set
        {
            _countdown.RemainingTime = value;
        }

    }

    public float DurationSeconds
    {
        get
        {
            return _config.DurationSeconds;
        }
    }

    protected System.Random random = new System.Random();

    private readonly ChestConfig _config;
    private readonly Countdown _countdown;
    

    public Chest(ChestConfig chest, MonoBehaviour context)
    {
        _config = chest;
        _countdown = new Countdown(context, _config.DurationSeconds);
    }

    public void Start()
    {
        if (IsActive == true)
        {
            throw new Exception("Already playing!");
        }

        _countdown.OnEnded += OnEndTime;
        _countdown.OnTimeChanged += OnChangeTime;

        OnStart();
        OnStarted?.Invoke(this);

        _countdown.Reset();
        _countdown.Play();
    }

    public void Stop()
    {
        _countdown.OnEnded -= OnEndTime;
        _countdown.OnTimeChanged -= OnChangeTime;
        OnStop();
    }

    public void Open()
    {
        OnOpen();
        GeneratingNewReward();
        Start();
    }

    protected abstract void OnStart();

    protected abstract void OnStop();

    protected abstract void OnOpen();

    protected abstract void GeneratingNewReward();

    private void OnChangeTime()
    {
        OnTimeChanged?.Invoke(this, RemainingSeconds);
    }

    private void OnEndTime()
    {
        _countdown.OnEnded -= OnEndTime;
        _countdown.OnTimeChanged -= OnChangeTime;

        OnCompleted?.Invoke(this);
    }
}