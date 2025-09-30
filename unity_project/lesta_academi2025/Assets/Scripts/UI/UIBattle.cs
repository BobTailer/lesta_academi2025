using System;
using UnityEditor.Playables;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI-менеджер для отображения информации о ходе боя.
/// </summary>
public class UIBattle : MonoBehaviour
{
    #region Ссылки на объекты и компоненты

    [SerializeField] private GameObject _uiBattleParant;
    [SerializeField] private GameObject _uiBattleInfo;

    [SerializeField] private Player _player;
    [SerializeField] private Enemy _enemy;

    #endregion

    #region Unity Events

    /// <summary>
    /// Подписка на события BattleManager и обработка событий смерти.
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

    #region Основная логика UI

    /// <summary>
    /// Очищает все бары информации о ходе боя.
    /// </summary>
    private void ClearBar()
    {
        foreach (Transform child in _uiBattleParant.transform)
        {
            Destroy(child.gameObject);
        }
    }

    /// <summary>
    /// Создаёт бар информации о промахе.
    /// </summary>
    /// <param name="attacker">Кто промахнулся</param>
    private void CreateMissBar(Attacker attacker)
    {
        GameObject infoBar = Instantiate(_uiBattleInfo, _uiBattleParant.transform);
        Text infoText = infoBar.GetComponentInChildren<Text>();
        if (infoText != null)
        {
            string attackerName = attacker == Attacker.Player ? "Игрок" : "Враг";
            infoText.text = $"{attackerName} промахнулся!";
        }
        infoBar.transform.SetParent(_uiBattleParant.transform, false);
    }

    /// <summary>
    /// Создаёт бар информации о нанесённом уроне.
    /// </summary>
    /// <param name="damage">Величина урона</param>
    /// <param name="attacker">Кто нанёс урон</param>
    private void CreateHitBar(int damage, Attacker attacker)
    {
        GameObject infoBar = Instantiate(_uiBattleInfo, _uiBattleParant.transform);
        Text infoText = infoBar.GetComponentInChildren<Text>();
        if (infoText != null)
        {
            string attackerName = attacker == Attacker.Player ? "Игрок" : "Враг";
            infoText.text = $"{attackerName} нанес {damage:+#;-#;0} урона";
        }
        infoBar.transform.SetParent(_uiBattleParant.transform, false);
    }

    /// <summary>
    /// Создаёт бар информации о применении способности игроком.
    /// </summary>
    /// <param name="ability">Способность</param>
    /// <param name="characters">Персонаж</param>
    /// <param name="damage">Величина урона</param>
    private void CreatePlayerAbilityBar(Abilities ability, Characters characters, int damage)
    {
        GameObject infoBar = Instantiate(_uiBattleInfo, _uiBattleParant.transform);
        Text infoText = infoBar.GetComponentInChildren<Text>();
        if (infoText != null)
        {
            infoText.text = $"{characters.characterName}: {ability.abilityName} {damage:+#;-#;0} урона";
        }
        infoBar.transform.SetParent(_uiBattleParant.transform, false);
    }

    /// <summary>
    /// Создаёт бар информации о применении способности врагом.
    /// </summary>
    /// <param name="ability">Способность</param>
    /// <param name="enemy">Враг</param>
    /// <param name="damage">Величина урона</param>
    private void CreateEnemyAbilityBar(Abilities ability, Enemies enemy, int damage)
    {
        GameObject infoBar = Instantiate(_uiBattleInfo, _uiBattleParant.transform);
        Text infoText = infoBar.GetComponentInChildren<Text>();
        if (infoText != null)
        {
            infoText.text = $"{enemy.enemyName}: {ability.abilityName} {damage:+#;-#;0} урона";
        }
        infoBar.transform.SetParent(_uiBattleParant.transform, false);
    }

    #endregion
}
