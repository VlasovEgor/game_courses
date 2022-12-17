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
            LoadRoutine();
        }
    }

    private void LoadRoutine()
    {
        InstallServices();
        LoadGameScene();
        LoadGameData();
        StartGame();

        _applicationLoaded = true;
    }

    private void InstallServices()
    {
        _serviceInstaller.InstallServices();
    }

    private void LoadGameScene()
    {

        SceneManager.LoadScene("GameScene");
        _gameContext = FindObjectOfType<GameContext>();
        _gameContext.LoadGame();
    }

    private void LoadGameData()
    {
        var dataLoader = ServiceLocator.GetService<IGameDataLoader>();

        dataLoader.LoadData(_gameContext);
        
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
        var dataSaver = ServiceLocator.GetService<IGameDataSaver>();
        dataSaver.SaveData(_gameContext);
        
    }
}
