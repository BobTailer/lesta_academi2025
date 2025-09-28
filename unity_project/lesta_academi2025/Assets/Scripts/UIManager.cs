using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
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

    [SerializeField] private Image _barbarianIcon;
    [SerializeField] private Text _barbarianName;
    [SerializeField] private Text _barbarianLevel;

    [SerializeField] private Image _warriorIcon;
    [SerializeField] private Text _warriorName;
    [SerializeField] private Text _warriorLevel;

    [Header("Character Details Panel")]
    [SerializeField] private GameObject _characterDetailsPanel;
    [SerializeField] private Image _characterDetailsIcon;
    [SerializeField] private Text _characterDetailsName;
    [SerializeField] private Text _characterDetailsDescription;

    [SerializeField] private GameObject _endPanel;
    [SerializeField] private GameObject _loosePanel;

    private void Start()
    {
        CharacterSelectPanelInitialize();
    }

    private void CharacterSelectPanelInitialize()
    {
        _banditIcon.sprite = _banditData.icon;
        _banditName.text = _banditData.characterName;
        _banditLevel.text = $"Уровень: {_banditData.level}";

        _barbarianIcon.sprite = _barbarianData.icon;
        _barbarianName.text = _barbarianData.characterName;
        _barbarianLevel.text = $"Уровень: {_barbarianData.level}";

        _warriorIcon.sprite = _warriorData.icon;
        _warriorName.text = _warriorData.characterName;
        _warriorLevel.text = $"Уровень: {_warriorData.level}";
    }

    public void CharacterDetails(Characters character)
    {
        _characterSelectPanel.SetActive(false);
        _endPanel.SetActive(false);
        _loosePanel.SetActive(false);
        _characterDetailsPanel.SetActive(true);

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
}
