using UnityEngine;

/// <summary>
/// Менеджер сцен. Управляет переходами между игровыми сценами и выходом из игры.
/// </summary>
public class SceneManager : Singleton<SceneManager>
{
    #region Поля

    [SerializeField] private string _gameSceneName;
    [SerializeField] private string _mainMenuSceneName;

    #endregion

    #region Методы перехода между сценами

    /// <summary>
    /// Запуск игровой сцены.
    /// </summary>
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_gameSceneName);
    }

    /// <summary>
    /// Возврат в главное меню.
    /// </summary>
    public void ReturnToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_mainMenuSceneName);
    }

    /// <summary>
    /// Выход из игры.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }

    #endregion
}
