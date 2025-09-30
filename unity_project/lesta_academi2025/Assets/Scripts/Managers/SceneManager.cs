using UnityEngine;

public class SceneManager : Singleton<SceneManager>
{
    [SerializeField] private string _gameSceneName;
    [SerializeField] private string _mainMenuSceneName;

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_gameSceneName);
    }

    public void ReturnToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_mainMenuSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
