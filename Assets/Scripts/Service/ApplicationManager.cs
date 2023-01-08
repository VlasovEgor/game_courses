using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplicationManager : MonoBehaviour
{
    [SerializeField] private ServiceInstaller _serviceInstaller;

    private bool _applicationLoaded;

    private GameContext _gameContext;

    [Button]
    public void LoadApplication()
    {
        if (!_applicationLoaded)
        {
            StartCoroutine(LoadRoutine());
        }
    }

    private IEnumerator LoadRoutine()
    {
        InstallServices();
        yield return LoadGameScene();
        LoadGameData();
        StartGame();

        _applicationLoaded = true;
    }

    private void InstallServices()
    {
        _serviceInstaller.InstallServices();
        
    }

    private IEnumerator LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
        yield return new WaitForEndOfFrame();

        _gameContext = FindObjectOfType<GameContext>();
        _gameContext.LoadGame();
    }

    private void LoadGameData()
    {
        var dataLoaders = ServiceLocator.GetServices<IGameDataLoader>();
        foreach (var dataLoader in dataLoaders)
        {
            dataLoader.LoadData(_gameContext);
        }
    }

    private void StartGame()
    {
        _gameContext.StartGame();
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            SaveGameData();
        }
    }

    private void OnApplicationQuit()
    {
        SaveGameData();
    }

    private void SaveGameData()
    {
        if (!_applicationLoaded)
        {
            return;
        }

        var dataSavers = ServiceLocator.GetServices<IGameDataSaver>();
        foreach (var dataSaver in dataSavers)
        {
            dataSaver.SaveData(_gameContext);
        }

    }
}
