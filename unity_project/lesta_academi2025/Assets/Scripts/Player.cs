using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Action OnDeath;

    private int _power;
    private int _agility;
    private int _endurance;

    private int _maxHP;
    private int _currentHP;

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
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnLevelUpgrade(Characters character)
    {
        character.level++;
        _maxHP += character.HpPerLevel + _endurance;
    }

    public void OnWeaponUpgrade(Weapon weapon)
    {
        _weapon = weapon;
    }

    public void ApplyDamage(int damage)
    {
        _currentHP -= damage;
        if (_currentHP <= 0)
        {
            OnDeath?.Invoke();
        }
    }

    private void OnDestroy()
    {
        OnDeath = null;
    }
}
