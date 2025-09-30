using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI-��������� ��� ����������� ���������� � ��������� �����.
/// </summary>
public class UIEnemyPanel : MonoBehaviour
{
    #region ������ �� ����������

    [SerializeField] private Enemies _enemy;
    [SerializeField] private Image _nextEnemyIcon;
    [SerializeField] private Text _nextEnemyName;

    #endregion

    #region Unity Events

    /// <summary>
    /// ������������� ������ ����� ��� ������� �����.
    /// </summary>
    private void Start()
    {
        UpdateEnemyPanel();
    }

    #endregion

    #region ��������������� ������

    /// <summary>
    /// ��������� ������ � ��� ���������� ����� �� ������.
    /// </summary>
    private void UpdateEnemyPanel()
    {
        _nextEnemyIcon.sprite = _enemy.icon;
        _nextEnemyName.text = _enemy.enemyName;
    }

    #endregion
}
