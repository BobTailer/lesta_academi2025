using UnityEngine;

public class SceneManager : Singleton<SceneManager>
{
    [SerializeField] private string _gameSceneName;

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_gameSceneName);
    }
}
