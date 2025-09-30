using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// ����� ������, ����������� �� Entity. ��������� ����������, �����������, ��������� � ��������������� � �����������.
/// </summary>
public class Player : Entity
{
    #region �������

    public Action OnDeath;
    public Action OnLevelUp;
    public Action OnDeathDelayStart;

    #endregion

    #region ���� � ��������

    private int _power;
    private int _agility;
    private int _endurance;

    public int power => _power;
    public int agility => _agility;
    public int endurance => _endurance;

    [SerializeField] private Characters[] _squad;
    private Weapon _weapon;

    public Characters[] squad => _squad;
    public Weapon weapon => _weapon;

    private AudioSource _audioSource;

    #endregion

    #region Unity Events

    private void Awake()
    {
        GameManager.Instance.LevelUpgrade += OnLevelUpgrade;
        GameManager.Instance.WeaponUpgrade += OnWeaponUpgrade;

        // ������������� ������� �������������
        _power = UnityEngine.Random.Range(1, 4);
        _agility = UnityEngine.Random.Range(1, 4);
        _endurance = UnityEngine.Random.Range(1, 4);
    }

    private void Start()
    {
        ResetCharactersLevel();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnDestroy()
    {
        ResetCharactersLevel();
        OnDeath = null;
        OnDeathDelayStart = null;
        OnLevelUp = null;
    }

    #endregion

    #region �������� ������

    /// <summary>
    /// ��������� ��������� ������ ���������.
    /// </summary>
    public void OnLevelUpgrade(Characters character)
    {
        character.level++;

        // ���������� ������ ������������
        foreach (var ability in character.abilities)
        {
            ability.currentLevel = character.level;
        }

        // ���������� �������� ������������
        foreach (var ability in character.abilities)
        {
            if (ability.abilityType == AbilityType.StatBoost)
            {
                int dmg = 0;
                ability.UseAbility(this, null, 0, ref dmg, ref dmg, DamageType.Chopping);
            }
        }

        // �������� ������������� ��������
        _maxHP = 0;
        foreach (var chara in _squad)
        {
            _maxHP += chara.HpPerLevel * chara.level + _endurance * chara.level;
        }
        _currentHP = _maxHP;
        OnLevelUp?.Invoke();
    }

    /// <summary>
    /// ��������� ��������� ������.
    /// </summary>
    public void OnWeaponUpgrade(Weapon weapon)
    {
        _weapon = weapon;
    }

    /// <summary>
    /// ��������� ���� ������.
    /// </summary>
    public void ApplyDamage(int damage)
    {
        Debug.Log($"Player takes {damage} damage");
        _currentHP -= damage;
        if (_currentHP <= 0)
        {
            _currentHP = 0;
            ResetCharactersLevel();
            Debug.Log("Player defeated!");
            _audioSource?.Play();
            OnDeathDelayStart?.Invoke(); // �������� � ������ ��������
            StartCoroutine(DeathDelayCoroutine());
        }
        Debug.Log($"Player HP: {_currentHP}/{_maxHP}");
    }

    /// <summary>
    /// �������� �������� ����� �������� ������.
    /// </summary>
    private IEnumerator DeathDelayCoroutine()
    {
        yield return new WaitForSeconds(3f);
        OnDeath?.Invoke();
        _currentHP = _maxHP;
    }

    /// <summary>
    /// ����� ������ ���� ���������� � ������.
    /// </summary>
    private void ResetCharactersLevel()
    {
        foreach (var character in _squad)
        {
            character.ResetLevel();
            foreach (var ability in character.abilities)
            {
                ability.currentLevel = 0;
            }
        }
    }

    /// <summary>
    /// ��������������� �������� ������ �� �������������.
    /// </summary>
    public void ResetHealth()
    {
        _currentHP = _maxHP;
    }

    /// <summary>
    /// �������� �������������� ������.
    /// </summary>
    public void UpgradeStats(int power, int agility, int endurance)
    {
        _power += power;
        _agility += agility;
        _endurance += endurance;
    }

    #endregion
}
