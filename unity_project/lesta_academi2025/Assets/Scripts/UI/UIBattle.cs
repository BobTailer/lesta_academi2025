using System;
using UnityEditor.Playables;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI-�������� ��� ����������� ���������� � ���� ���.
/// </summary>
public class UIBattle : MonoBehaviour
{
    #region ������ �� ������� � ����������

    [SerializeField] private GameObject _uiBattleParant;
    [SerializeField] private GameObject _uiBattleInfo;

    [SerializeField] private Player _player;
    [SerializeField] private Enemy _enemy;

    #endregion

    #region Unity Events

    /// <summary>
    /// �������� �� ������� BattleManager � ��������� ������� ������.
    /// </summary>
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

    #endregion

    #region �������� ������ UI

    /// <summary>
    /// ������� ��� ���� ���������� � ���� ���.
    /// </summary>
    private void ClearBar()
    {
        foreach (Transform child in _uiBattleParant.transform)
        {
            Destroy(child.gameObject);
        }
    }

    /// <summary>
    /// ������ ��� ���������� � �������.
    /// </summary>
    /// <param name="attacker">��� �����������</param>
    private void CreateMissBar(Attacker attacker)
    {
        GameObject infoBar = Instantiate(_uiBattleInfo, _uiBattleParant.transform);
        Text infoText = infoBar.GetComponentInChildren<Text>();
        if (infoText != null)
        {
            string attackerName = attacker == Attacker.Player ? "�����" : "����";
            infoText.text = $"{attackerName} �����������!";
        }
        infoBar.transform.SetParent(_uiBattleParant.transform, false);
    }

    /// <summary>
    /// ������ ��� ���������� � ��������� �����.
    /// </summary>
    /// <param name="damage">�������� �����</param>
    /// <param name="attacker">��� ���� ����</param>
    private void CreateHitBar(int damage, Attacker attacker)
    {
        GameObject infoBar = Instantiate(_uiBattleInfo, _uiBattleParant.transform);
        Text infoText = infoBar.GetComponentInChildren<Text>();
        if (infoText != null)
        {
            string attackerName = attacker == Attacker.Player ? "�����" : "����";
            infoText.text = $"{attackerName} ����� {damage:+#;-#;0} �����";
        }
        infoBar.transform.SetParent(_uiBattleParant.transform, false);
    }

    /// <summary>
    /// ������ ��� ���������� � ���������� ����������� �������.
    /// </summary>
    /// <param name="ability">�����������</param>
    /// <param name="characters">��������</param>
    /// <param name="damage">�������� �����</param>
    private void CreatePlayerAbilityBar(Abilities ability, Characters characters, int damage)
    {
        GameObject infoBar = Instantiate(_uiBattleInfo, _uiBattleParant.transform);
        Text infoText = infoBar.GetComponentInChildren<Text>();
        if (infoText != null)
        {
            infoText.text = $"{characters.characterName}: {ability.abilityName} {damage:+#;-#;0} �����";
        }
        infoBar.transform.SetParent(_uiBattleParant.transform, false);
    }

    /// <summary>
    /// ������ ��� ���������� � ���������� ����������� ������.
    /// </summary>
    /// <param name="ability">�����������</param>
    /// <param name="enemy">����</param>
    /// <param name="damage">�������� �����</param>
    private void CreateEnemyAbilityBar(Abilities ability, Enemies enemy, int damage)
    {
        GameObject infoBar = Instantiate(_uiBattleInfo, _uiBattleParant.transform);
        Text infoText = infoBar.GetComponentInChildren<Text>();
        if (infoText != null)
        {
            infoText.text = $"{enemy.enemyName}: {ability.abilityName} {damage:+#;-#;0} �����";
        }
        infoBar.transform.SetParent(_uiBattleParant.transform, false);
    }

    #endregion
}
