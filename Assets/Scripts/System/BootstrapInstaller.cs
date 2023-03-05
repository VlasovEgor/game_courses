using UnityEngine;
using Zenject;

public class BootstrapInstaller : MonoInstaller
{
    [SerializeField] private RealtimeManager _realtimeManager;

    public override void InstallBindings()
    {
        BindRealtimeManager();
        BindRealtimeRepository();
        BindRealtimeSessionSaver();

        BindChestsData();
        BindChestsRepository();
    }
    
    private void BindRealtimeManager()
    {
        Container.Bind<RealtimeManager>().
            FromComponentInNewPrefab(_realtimeManager).
            AsSingle().
            NonLazy();
    }

    private void BindRealtimeRepository()
    {
        Container.Bind<RealtimeRepository>().
            AsSingle().
            NonLazy();
    }

    private void BindRealtimeSessionSaver()
    {
        Container.BindInterfacesAndSelfTo<RealtimeSessionSaver>().
            AsSingle().
            NonLazy();
    }
    private void BindChestsData()
    {
        Container.Bind<ChestsData>().
            AsSingle().
            NonLazy();
    }

    private void BindChestsRepository()
    {
        Container.Bind<ChestsRepository>().
            AsSingle().
            NonLazy();
    }
}
