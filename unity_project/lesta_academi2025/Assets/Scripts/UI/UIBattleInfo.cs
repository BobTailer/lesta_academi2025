using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI-��������� ��� ����������� �������� ���� ��� � ����������.
/// </summary>
public class UIBattleInfo : MonoBehaviour
{
    #region ������ �� UI-��������

    [SerializeField] private Text _battleSteps;
    [SerializeField] private Text _currentAttacker;

    #endregion

    #region Unity Events

    /// <summary>
    /// ������ ���� ��������� ���������� � ���� ��� � ������� ���������.
    /// </summary>
    private void Update()
    {
        UpdateBattleStepText();
        UpdateCurrentAttackerText();
    }

    #endregion

    #region ��������������� ������

    /// <summary>
    /// ��������� ����� ���� ���.
    /// </summary>
    private void UpdateBattleStepText()
    {
        _battleSteps.text = $"���: {BattleManager.Instance.steps}";
    }

    /// <summary>
    /// ��������� ����� �������� ����������.
    /// </summary>
    private void UpdateCurrentAttackerText()
    {
        if (BattleManager.Instance.currentAttacker == Attacker.Player)
        {
            _currentAttacker.text = "�������: �����";
        }
        else
        {
            _currentAttacker.text = "�������: ����";
        }
    }

    #endregion
}
