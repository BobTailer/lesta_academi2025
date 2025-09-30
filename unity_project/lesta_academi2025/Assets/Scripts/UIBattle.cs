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
        // Создаём объект из префаба
        GameObject infoBar = Instantiate(_uiBattleInfo, _uiBattleParant.transform);

        // Находим компонент Text
        Text infoText = infoBar.GetComponentInChildren<Text>();
        if (infoText != null)
        {
            // Формируем строку: Игрок/Враг промахнулся
            string attackerName = attacker == Attacker.Player ? "Игрок" : "Враг";
            infoText.text = $"{attackerName} промахнулся!";
        }

        infoBar.transform.SetParent(_uiBattleParant.transform, false);
    }

    private void CreateHitBar(int damage, Attacker attacker)
    {
        // Создаём объект из префаба
        GameObject infoBar = Instantiate(_uiBattleInfo, _uiBattleParant.transform);

        // Находим компонент Text
        Text infoText = infoBar.GetComponentInChildren<Text>();
        if (infoText != null)
        {
            // Формируем строку: Игрок/Враг нанес урон
            string attackerName = attacker == Attacker.Player ? "Игрок" : "Враг";
            infoText.text = $"{attackerName} нанес {damage:+#;-#;0} урона";
        }

        infoBar.transform.SetParent(_uiBattleParant.transform, false);
    }

    private void CreatePlayerAbilityBar(Abilities ability, Characters characters, int damage)
    {
        // Создаём объект из префаба
        GameObject infoBar = Instantiate(_uiBattleInfo, _uiBattleParant.transform);

        // Находим компонент Text
        Text infoText = infoBar.GetComponentInChildren<Text>();
        if (infoText != null)
        {
            // Формируем строку: Имя врага: Имя способности - нанесённый урон
            infoText.text = $"{characters.characterName}: {ability.abilityName} {damage:+#;-#;0} урона";
        }

        // Устанавливаем родителя (если не указан в Instantiate)
        infoBar.transform.SetParent(_uiBattleParant.transform, false);
    }

    private void CreateEnemyAbilityBar(Abilities ability, Enemies enemy, int damage)
    {
        // Создаём объект из префаба
        GameObject infoBar = Instantiate(_uiBattleInfo, _uiBattleParant.transform);

        // Находим компонент Text
        Text infoText = infoBar.GetComponentInChildren<Text>();
        if (infoText != null)
        {
            // Формируем строку: Имя врага: Имя способности - нанесённый урон
            infoText.text = $"{enemy.enemyName}: {ability.abilityName} {damage:+#;-#;0} урона";
        }

        // Устанавливаем родителя (если не указан в Instantiate)
        infoBar.transform.SetParent(_uiBattleParant.transform, false);
    }

}
