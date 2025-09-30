using UnityEngine;

/// <summary>
/// �������� ����. ��������� ���������� ����� �������� ������� � ������� �� ����.
/// </summary>
public class SceneManager : Singleton<SceneManager>
{
    #region ����

    [SerializeField] private string _gameSceneName;
    [SerializeField] private string _mainMenuSceneName;

    #endregion

    #region ������ �������� ����� �������

    /// <summary>
    /// ������ ������� �����.
    /// </summary>
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_gameSceneName);
    }

    /// <summary>
    /// ������� � ������� ����.
    /// </summary>
    public void ReturnToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_mainMenuSceneName);
    }

    /// <summary>
    /// ����� �� ����.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }

    #endregion
}
