using UnityEngine;
using UnityEngine.UI;

public class UIBattleInfo : MonoBehaviour
{
    [SerializeField] private Text _battleSteps;
    [SerializeField] private Text _currentAttacker;

    private void Update()
    {
        _battleSteps.text = $"���: {BattleManager.Instance.steps}";
        if (BattleManager.Instance.currentAttacker == Attacker.Player)
        {
            _currentAttacker.text = "�������: �����";
        }
        else
        {
            _currentAttacker.text = "�������: ����";
        }
    }
}
