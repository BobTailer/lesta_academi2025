using System;
using UnityEditor.Playables;
using UnityEngine;
using UnityEngine.UI;

public class UIBattle : MonoBehaviour
{
    [SerializeField] private GameObject _uiBattleParant;
    [SerializeField] private GameObject _uiBattleInfo;

    [SerializeField] private Player _player;
    [SerializeField] private Enemy _enemy;

    private void Start()
    {
        BattleManager.Instance.OnEnemyAbilityUsed += CreateEnemyAbilityBar;
        BattleManager.Instance.OnPlayerAbilityUsed += CreatePlayerAbilityBar;
        BattleManager.Instance.OnHit += CreateHitBar;
        BattleManager.Instance.OnMiss += CreateMissBar;
        BattleManager.Instance.OnSwitch += ClearBar;
        _player.OnDeath += ClearBar;
        _enemy.OnDeath += ClearBar;
    }

    private void ClearBar()
    {
        foreach (Transform child in _uiBattleParant.transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void CreateMissBar(Attacker attacker)
    {
        // ������ ������ �� �������
        GameObject infoBar = Instantiate(_uiBattleInfo, _uiBattleParant.transform);

        // ������� ��������� Text
        Text infoText = infoBar.GetComponentInChildren<Text>();
        if (infoText != null)
        {
            // ��������� ������: �����/���� �����������
            string attackerName = attacker == Attacker.Player ? "�����" : "����";
            infoText.text = $"{attackerName} �����������!";
        }

        infoBar.transform.SetParent(_uiBattleParant.transform, false);
    }

    private void CreateHitBar(int damage, Attacker attacker)
    {
        // ������ ������ �� �������
        GameObject infoBar = Instantiate(_uiBattleInfo, _uiBattleParant.transform);

        // ������� ��������� Text
        Text infoText = infoBar.GetComponentInChildren<Text>();
        if (infoText != null)
        {
            // ��������� ������: �����/���� ����� ����
            string attackerName = attacker == Attacker.Player ? "�����" : "����";
            infoText.text = $"{attackerName} ����� {damage:+#;-#;0} �����";
        }

        infoBar.transform.SetParent(_uiBattleParant.transform, false);
    }

    private void CreatePlayerAbilityBar(Abilities ability, Characters characters, int damage)
    {
        // ������ ������ �� �������
        GameObject infoBar = Instantiate(_uiBattleInfo, _uiBattleParant.transform);

        // ������� ��������� Text
        Text infoText = infoBar.GetComponentInChildren<Text>();
        if (infoText != null)
        {
            // ��������� ������: ��� �����: ��� ����������� - ��������� ����
            infoText.text = $"{characters.characterName}: {ability.abilityName} {damage:+#;-#;0} �����";
        }

        // ������������� �������� (���� �� ������ � Instantiate)
        infoBar.transform.SetParent(_uiBattleParant.transform, false);
    }

    private void CreateEnemyAbilityBar(Abilities ability, Enemies enemy, int damage)
    {
        // ������ ������ �� �������
        GameObject infoBar = Instantiate(_uiBattleInfo, _uiBattleParant.transform);

        // ������� ��������� Text
        Text infoText = infoBar.GetComponentInChildren<Text>();
        if (infoText != null)
        {
            // ��������� ������: ��� �����: ��� ����������� - ��������� ����
            infoText.text = $"{enemy.enemyName}: {ability.abilityName} {damage:+#;-#;0} �����";
        }

        // ������������� �������� (���� �� ������ � Instantiate)
        infoBar.transform.SetParent(_uiBattleParant.transform, false);
    }

}
