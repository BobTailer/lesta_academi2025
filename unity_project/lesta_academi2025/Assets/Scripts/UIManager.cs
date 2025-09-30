using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Enemy _enemy;

    [Header("Characters Data")]
    [SerializeField] private Characters _banditData;
    [SerializeField] private Characters _barbarianData;
    [SerializeField] private Characters _warriorData;

    [Header("Enemies Data")]
    [SerializeField] private Enemies _goblinData;
    [SerializeField] private Enemies _skeletonData;
    [SerializeField] private Enemies _slimeData;
    [SerializeField] private Enemies _ghostData;
    [SerializeField] private Enemies _golemData;
    [SerializeField] private Enemies _dragonData;

    [Header("Weapons Data")]
    [SerializeField] private Weapon _swordData;
    [SerializeField] private Weapon _axeData;
    [SerializeField] private Weapon _cudgelData;
    [SerializeField] private Weapon _duggerData;
    [SerializeField] private Weapon _spearData;
    [SerializeField] private Weapon _legendarySwordData;

    [Header("Abilities Data")]
    [SerializeField] private Abilities _fireBreathData;
    [SerializeField] private Abilities _ImpulseData;
    [SerializeField] private Abilities _poisonData;
    [SerializeField] private Abilities _rageData;
    [SerializeField] private Abilities _stealthAttackData;
    [SerializeField] private Abilities _stoneSkinData;
    [SerializeField] private Abilities _shieldData;
    [SerializeField] private Abilities _ImmuneChoppingData;
    [SerializeField] private Abilities _defencelessCrushingData;
    [SerializeField] private Abilities _agilityUpgradeData;
    [SerializeField] private Abilities _enduranceUpgradeData;
    [SerializeField] private Abilities _powerUpgradeData;

    [Header("Characters Select Panels")]
    [SerializeField] private GameObject _characterSelectPanel;
    [SerializeField] private Image _banditIcon;
    [SerializeField] private Text _banditName;
    [SerializeField] private Text _banditLevel;
    [SerializeField] private Button _banditButton;

    [SerializeField] private Image _barbarianIcon;
    [SerializeField] private Text _barbarianName;
    [SerializeField] private Text _barbarianLevel;
    [SerializeField] private Button _barbarianButton;

    [SerializeField] private Image _warriorIcon;
    [SerializeField] private Text _warriorName;
    [SerializeField] private Text _warriorLevel;
    [SerializeField] private Button _warriorButton;

    [Header("Character Details Panel")]
    [SerializeField] private GameObject _characterDetailsPanel;
    [SerializeField] private Image _characterDetailsIcon;
    [SerializeField] private Text _characterDetailsName;
    [SerializeField] private Text _characterDetailsDescription;
    [SerializeField] private GameObject _characterDetailsWeaponPanel;
    [SerializeField] private Image _characterDetailsWeaponIcon;
    [SerializeField] private Text _characterDetailsWeaponName;
    [SerializeField] private Text _characterDetailsWeaponDescription;

    [Header("Enemy Details Panel")]
    [SerializeField] private GameObject _enemyDetailsPanel;
    [SerializeField] private Image _enemyDetailsIcon;
    [SerializeField] private Text _enemyDetailsName;
    [SerializeField] private Text _enemyDetailsDescription;
    [SerializeField] private GameObject _enemyRewardPanel;
    [SerializeField] private Image _enemyRewardIcon;
    [SerializeField] private Text _enemyRewardName;
    [SerializeField] private Text _enemyRewardDescription;

    [Header("Next Enemy Panel")]
    [SerializeField] private GameObject _nextEnemyPanel;
    [SerializeField] private Image _nextEnemyIcon;
    [SerializeField] private Text _nextEnemyName;

    [Header("Reward Panel")]
    [SerializeField] private GameObject _rewardPanel;
    [SerializeField] private Image _rewardIcon;
    [SerializeField] private Text _rewardName;
    [SerializeField] private Text _rewardDescription;
    [SerializeField] private Button _rewardButton;

    [Header("Weapon Panel")]
    [SerializeField] private GameObject _weaponPanel;
    [SerializeField] private Image _weaponIcon;
    [SerializeField] private Text _weaponName;
    [SerializeField] private Text _weaponDescription;

    [Header("StatsPanel")]
    [SerializeField] private GameObject _statsPanel;
    [SerializeField] private Button _weaponButton;
    [SerializeField] private Text _statsText;
    [SerializeField] private Text _healthText;

    [Header("BeginPanel")]
    [SerializeField] private Text _progressText;
    [SerializeField] private Button _beginButton;

    [Header("GamePanel")]
    [SerializeField] private GameObject _battlePanel;
    [SerializeField] private GameObject _loosePanel;
    [SerializeField] private GameObject _winPanel;

    private Enemies _nextEnemy;

    private void Awake()
    {
        GameManager.Instance.AfterEnemyDeath += CharacterSelectPanelInitialize;
        GameManager.Instance.AfterPlayerDeath += LoosePanelInitialize;
        GameManager.Instance.EnemyChange += NextEnemyPanelInitialize;
        GameManager.Instance.Battle += BattlePanelInitialize;
        GameManager.Instance.OnGameOver += WinPanelInitialize;

        _player.OnLevelUp += CharacterSelectPanelInitialize;
    }

    private void Start()
    {
        CharacterSelectPanelInitialize();
    }

    public void CharacterSelectPanelInitialize()
    {
        if (GameManager.Instance.battleCount >= GameManager.Instance.maxBattles) return;

        _characterSelectPanel.SetActive(true);
        _battlePanel.SetActive(false);
        _characterDetailsPanel.SetActive(false);
        _enemyDetailsPanel.SetActive(false);

        CheckButtonImteractible();

        _rewardButton.interactable = true;

        _banditIcon.sprite = _banditData.icon;
        _banditName.text = _banditData.characterName;
        _banditLevel.text = $"Уровень: {_banditData.level}";

        _barbarianIcon.sprite = _barbarianData.icon;
        _barbarianName.text = _barbarianData.characterName;
        _barbarianLevel.text = $"Уровень: {_barbarianData.level}";

        _warriorIcon.sprite = _warriorData.icon;
        _warriorName.text = _warriorData.characterName;
        _warriorLevel.text = $"Уровень: {_warriorData.level}";

        if (GameManager.Instance.weapon != null)
        {
            _rewardPanel.SetActive(true);
            _rewardIcon.sprite = GameManager.Instance.weapon.icon;
            _rewardName.text = GameManager.Instance.weapon.weaponName;
            _rewardDescription.text = $"Атка: {GameManager.Instance.weapon.atk}\nТип урона: {GameManager.Instance.weapon.damageTypeString}";
        }
        else
        {
            _rewardPanel.SetActive(false);
        }

        if (_banditData.level == 0 & _barbarianData.level == 0 & _warriorData.level == 0)
        {
            _beginButton.interactable = false;
            _weaponButton.interactable = false;
        }
        else
        {
            _beginButton.interactable = true;
            _weaponButton.interactable = true;
        }

        _statsText.text = $"Параметры персонажа:\nСила: {_player.power}\nЛовкость: {_player.agility}\nВыносливость: {_player.endurance}";
        _healthText.text = $"Здоровье: {_player.maxHP}";

        _progressText.text = $"Прогресс: {GameManager.Instance.battleCount}/{GameManager.Instance.maxBattles}";

        NextEnemyDetails(_nextEnemy);
    }

    public void CharacterDetails(Characters character)
    {
        _characterSelectPanel.SetActive(false);
        _characterDetailsPanel.SetActive(true);

        var level = _banditData.level + _barbarianData.level + _warriorData.level;
        if (level != 0)
        {
            _characterDetailsWeaponPanel.SetActive(false);
        }
        else
        {
            _characterDetailsWeaponPanel.SetActive(true);
            _characterDetailsWeaponIcon.sprite = character.weapon.icon;
            _characterDetailsWeaponName.text = character.weapon.weaponName;
            _characterDetailsWeaponDescription.text = $"Атка: {character.weapon.atk}\nТип урона: {character.weapon.damageTypeString}";
        }

            _characterDetailsIcon.sprite = character.icon;
        _characterDetailsName.text = character.characterName;

        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.AppendLine($"Здоровье за уровень: {character.HpPerLevel}\n");
        sb.AppendLine("Способности:\n");

        foreach (var ability in character.abilities)
        {
            sb.AppendLine($"{ability.abilityName} (уровень {ability.requiredLevel}):");
            sb.AppendLine(ability.abilityDescription);
            sb.AppendLine();
        }

        _characterDetailsDescription.text = sb.ToString();
    }

    private void NextEnemyPanelInitialize(Enemies enemy)
    {
        _nextEnemy = enemy;

        _nextEnemyIcon.sprite = enemy.icon;
        _nextEnemyName.text = enemy.enemyName;

        NextEnemyDetails(_nextEnemy);
    }

    public void NextEnemyDetails(Enemies enemy)
    {
        if (enemy == null) return;

        _enemyDetailsIcon.sprite = enemy.icon;
        _enemyDetailsName.text = enemy.enemyName;

        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.AppendLine($"Имя: {enemy.enemyName}");
        sb.AppendLine($"Здоровье: {enemy.hp}");
        sb.AppendLine($"Сила: {enemy.power}");
        sb.AppendLine($"Урон оружия: {enemy.atk}");
        sb.AppendLine($"Ловкость: {enemy.agility}");
        sb.AppendLine($"Выносливость: {enemy.endurance}");

        if (enemy.ability != null)
        {
            sb.AppendLine("\nСпособность:");
            sb.AppendLine($"{enemy.ability.abilityName}:");
            sb.AppendLine(enemy.ability.abilityDescription);
        }
        else
        {
            sb.AppendLine("\nСпособность: отсутствует");
        }

        _enemyDetailsDescription.text = sb.ToString();

        if (enemy.reward != null)
        {
            _enemyRewardPanel.SetActive(true);
            _enemyRewardIcon.sprite = enemy.reward.icon;
            _enemyRewardName.text = enemy.reward.weaponName;
            _enemyRewardDescription.text = $"Атка: {enemy.reward.atk}\nТип урона: {enemy.reward.damageTypeString}";
        }
        else
        {
            _enemyRewardPanel.SetActive(false);
        }
    }

    public void WeaponDetails()
    {
        _weaponIcon.sprite = _player.weapon.icon;
        _weaponName.text = _player.weapon.weaponName;
        _weaponDescription.text = $"Атка: {_player.weapon.atk}\nТип урона: {_player.weapon.damageTypeString}";
    }

    private void CheckButtonImteractible()
    {
        var level = _banditData.level + _barbarianData.level + _warriorData.level;
        if (level == GameManager.Instance.battleCount)
        {
            _banditButton.interactable = true;
            _barbarianButton.interactable = true;
            _warriorButton.interactable = true;
        }

        if (_banditData.level == 3)
            _banditButton.interactable = false;
        if (_barbarianData.level == 3)
            _barbarianButton.interactable = false;
        if (_warriorData.level == 3)
            _warriorButton.interactable = false;

        if (_player.weapon == GameManager.Instance.weapon)
        {
            _rewardButton.interactable = false;
        }
        else
        {
            _rewardButton.interactable = true;
        }
    }

    private void LoosePanelInitialize()
    {
        _characterSelectPanel.SetActive(false);
        _battlePanel.SetActive(false);
        _winPanel.SetActive(false);
        _loosePanel.SetActive(true);
    }

    private void BattlePanelInitialize()
    {
        _characterSelectPanel.SetActive(false);
        _battlePanel.SetActive(true);
        _winPanel.SetActive(false);
        _loosePanel.SetActive(false);
    }

    private void WinPanelInitialize()
    {
        _characterSelectPanel.SetActive(false);
        _battlePanel.SetActive(false);
        _winPanel.SetActive(true);
        _loosePanel.SetActive(false);
    }
}
