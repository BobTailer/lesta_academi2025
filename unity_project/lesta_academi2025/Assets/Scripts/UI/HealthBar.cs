using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ��������� ��� ����������� � ���������� ������� �������� ��������.
/// </summary>
public class HealthBar : MonoBehaviour
{
    #region ������ �� ����������

    [SerializeField] private Entity _entity;
    [SerializeField] private Image _fillBar;
    [SerializeField] private Text _healthText;

    #endregion

    #region Unity Events

    /// <summary>
    /// ������ ���� ��������� ����������� ��������.
    /// </summary>
    private void Update()
    {
        if (_entity == null) return;

        UpdateHealthText();
        UpdateFillBar();
    }

    #endregion

    #region ��������������� ������

    /// <summary>
    /// ��������� ��������� ����������� �������� � ������������� ��������.
    /// </summary>
    private void UpdateHealthText()
    {
        _healthText.text = $"{_entity.currentHP} / {_entity.maxHP}";
    }

    /// <summary>
    /// ��������� ���������� ������� ��������.
    /// </summary>
    private void UpdateFillBar()
    {
        float fillAmount = _entity.maxHP > 0 ? (float)_entity.currentHP / _entity.maxHP : 0f;
        _fillBar.fillAmount = Mathf.Clamp01(fillAmount);
    }

    #endregion
}
