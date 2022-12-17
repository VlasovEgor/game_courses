using UnityEngine;
using UnityEngine.Serialization;

public class ServiceInstaller : MonoBehaviour
{
    [SerializeField] private bool _installOnAwake;

    [Space]
    [SerializeField]
    [FormerlySerializedAs("serviceLoaders")]
    private ServicePack[] _servicePacks;

    private void Awake()
    {
        if (_installOnAwake)
        {
            InstallServices();
        }
    }

    public void InstallServices()
    {
        InstallServicesFromPacks();
    }

    private void InstallServicesFromPacks()
    {
        for (int i = 0, count = _servicePacks.Length; i < count; i++)
        {
            var serviceLoader = _servicePacks[i];
            var services = serviceLoader.LoadServices();
            for (int j = 0, length = services.Length; j < length; j++)
            {
                var service = services[j];
                ServiceLocator.AddService(service);
            }
        }
    }
}