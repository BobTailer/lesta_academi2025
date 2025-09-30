using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI-компонент для отображения текущего шага боя и атакующего.
/// </summary>
public class UIBattleInfo : MonoBehaviour
{
    #region Ссылки на UI-элементы

    [SerializeField] private Text _battleSteps;
    [SerializeField] private Text _currentAttacker;

    #endregion

    #region Unity Events

    /// <summary>
    /// Каждый кадр обновляет информацию о ходе боя и текущем атакующем.
    /// </summary>
    private void Update()
    {
        UpdateBattleStepText();
        UpdateCurrentAttackerText();
    }

    #endregion

    #region Вспомогательные методы

    /// <summary>
    /// Обновляет текст шага боя.
    /// </summary>
    private void UpdateBattleStepText()
    {
        _battleSteps.text = $"Ход: {BattleManager.Instance.steps}";
    }

    /// <summary>
    /// Обновляет текст текущего атакующего.
    /// </summary>
    private void UpdateCurrentAttackerText()
    {
        if (BattleManager.Instance.currentAttacker == Attacker.Player)
        {
            _currentAttacker.text = "Атакует: Игрок";
        }
        else
        {
            _currentAttacker.text = "Атакует: Враг";
        }
    }

    #endregion
}
