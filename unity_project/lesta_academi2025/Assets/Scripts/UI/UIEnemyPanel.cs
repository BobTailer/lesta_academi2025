using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI-компонент для отображения информации о следующем враге.
/// </summary>
public class UIEnemyPanel : MonoBehaviour
{
    #region Ссылки на компоненты

    [SerializeField] private Enemies _enemy;
    [SerializeField] private Image _nextEnemyIcon;
    [SerializeField] private Text _nextEnemyName;

    #endregion

    #region Unity Events

    /// <summary>
    /// Инициализация панели врага при запуске сцены.
    /// </summary>
    private void Start()
    {
        UpdateEnemyPanel();
    }

    #endregion

    #region Вспомогательные методы

    /// <summary>
    /// Обновляет иконку и имя следующего врага на панели.
    /// </summary>
    private void UpdateEnemyPanel()
    {
        _nextEnemyIcon.sprite = _enemy.icon;
        _nextEnemyName.text = _enemy.enemyName;
    }

    #endregion
}
