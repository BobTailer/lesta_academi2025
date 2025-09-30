using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Компонент для отображения и обновления полоски здоровья сущности.
/// </summary>
public class HealthBar : MonoBehaviour
{
    #region Ссылки на компоненты

    [SerializeField] private Entity _entity;
    [SerializeField] private Image _fillBar;
    [SerializeField] private Text _healthText;

    #endregion

    #region Unity Events

    /// <summary>
    /// Каждый кадр обновляет отображение здоровья.
    /// </summary>
    private void Update()
    {
        if (_entity == null) return;

        UpdateHealthText();
        UpdateFillBar();
    }

    #endregion

    #region Вспомогательные методы

    /// <summary>
    /// Обновляет текстовое отображение текущего и максимального здоровья.
    /// </summary>
    private void UpdateHealthText()
    {
        _healthText.text = $"{_entity.currentHP} / {_entity.maxHP}";
    }

    /// <summary>
    /// Обновляет заполнение полоски здоровья.
    /// </summary>
    private void UpdateFillBar()
    {
        float fillAmount = _entity.maxHP > 0 ? (float)_entity.currentHP / _entity.maxHP : 0f;
        _fillBar.fillAmount = Mathf.Clamp01(fillAmount);
    }

    #endregion
}
