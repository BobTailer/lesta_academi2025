using UnityEngine;
using UnityEngine.UI;

public class UIBattleInfo : MonoBehaviour
{
    [SerializeField] private Text _battleSteps;
    [SerializeField] private Text _currentAttacker;

    private void Update()
    {
        _battleSteps.text = $"Ход: {BattleManager.Instance.steps}";
        if (BattleManager.Instance.currentAttacker == Attacker.Player)
        {
            _currentAttacker.text = "Атакует: Игрок";
        }
        else
        {
            _currentAttacker.text = "Атакует: Враг";
        }
    }
}
