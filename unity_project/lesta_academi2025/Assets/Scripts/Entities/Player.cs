using System;
using System.Collections;
using UnityEngine;

public class Player : Entity
{
    public Action OnDeath;
    public Action OnDeathDelayStart;

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

    private void Awake()
    {
        GameManager.Instance.LevelUpgrade += OnLevelUpgrade;
        GameManager.Instance.WeaponUpgrade += OnWeaponUpgrade;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _power = UnityEngine.Random.Range(1, 4);
        _agility = UnityEngine.Random.Range(1, 4);
        _endurance = UnityEngine.Random.Range(1, 4);

        ResetCharactersLevel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnLevelUpgrade(Characters character)
    {
        character.level++;

        foreach (var ability in character.abilities)
        {
            ability.currentLevel = character.level;
        }

        foreach (var ability in character.abilities)
        {
            if (ability.abilityType == AbilityType.StatBoost)
            {
                int dmg = 0;
                ability.UseAbility(this, null, 0, ref dmg, ref dmg, DamageType.Chopping);
            }
        }

            _maxHP += character.HpPerLevel + _endurance;
        _currentHP = _maxHP;
}

    public void OnWeaponUpgrade(Weapon weapon)
    {
        _weapon = weapon;
    }

    public void ApplyDamage(int damage)
    {
        Debug.Log($"Player takes {damage} damage");
        _currentHP -= damage;
        if (_currentHP <= 0)
        {
            _currentHP = 0;
            ResetCharactersLevel();
            Debug.Log("Player defeated!");
            OnDeathDelayStart?.Invoke(); // Сообщаем о начале задержки
            StartCoroutine(DeathDelayCoroutine());
        }
        Debug.Log($"Player HP: {_currentHP}/{_maxHP}");
    }

    private IEnumerator DeathDelayCoroutine()
    {
        yield return new WaitForSeconds(3f);
        OnDeath?.Invoke();
        _currentHP = _maxHP;
    }

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

    public void ResetHealth()
    {
        _currentHP = _maxHP;
    } 

    public void UpgradeStats(int power, int agility, int endurance)
    {
        _power += power;
        _agility += agility;
        _endurance += endurance;
    }

    private void OnDestroy()
    {
        OnDeath = null;
        OnDeathDelayStart = null;
    }
}
