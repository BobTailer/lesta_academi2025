using System.Collections;
using UnityEngine;

public enum Attacker
{
    Player,
    Enemy
}

public class BattleManager : Singleton<BattleManager>
{
    private Attacker _currentAttacker = Attacker.Player;

    private int _steps;
    public int steps => _steps;

    [SerializeField] private Player _player;
    [SerializeField] private Enemy _enemy;

    private int _damage;
    private int _weaponDamage;
    private DamageType _damageType;

    private bool _battleRoutineRunning = false;

    private void Start()
    {
        GameManager.Instance.Battle += OnBattleStart;
    }

    private void Update()
    {
        if (GameManager.Instance.currentState == GameState.Battle && !_battleRoutineRunning)
        {
            StartCoroutine(BattleRoutine());
        }
    }

    private IEnumerator BattleRoutine()
    {
        _battleRoutineRunning = true;

        if (AttackChance())
        {
            CalculateDamage();
            ApplyDamage();
            Debug.Log($"{_currentAttacker} hits for {_damage} damage (Weapon Damage: {_weaponDamage}, Damage Type: {_damageType})");
        }
        else
        {
            Debug.Log($"{_currentAttacker} misses!");
        }
        // Switch turns
        _currentAttacker = _currentAttacker == Attacker.Player ? Attacker.Enemy : Attacker.Player;
        _steps++;

        yield return new WaitForSeconds(1f); // Пауза 1 секунда

        _battleRoutineRunning = false;
    }

    private void OnBattleStart()
    {
        if (_player.agility >= _enemy.enemyData.agility)
        {
            // Player attacks first
            _currentAttacker = Attacker.Player;
        }
        else
        {
            // Enemy attacks first
            _currentAttacker = Attacker.Enemy;
        }
    }

    private bool AttackChance()
    {
        var general_agility = _player.agility + _enemy.enemyData.agility;
        var chance = Random.Range(1, general_agility + 1);
        if (_currentAttacker == Attacker.Player)
        {
            return chance > _enemy.enemyData.agility;
        }
        else
        {
            return chance > _player.agility;
        }
    }

    private void CalculateDamage()
    {
        int damage;
        int weaponDamage;
        DamageType damageType;

        if (_currentAttacker == Attacker.Player)
        {
            weaponDamage = _player.weapon != null ? _player.weapon.atk : 0;
            damage = _player.power + weaponDamage;
            damageType = _player.weapon != null ? _player.weapon.damageType : DamageType.Chopping;
        }
        else
        {
            weaponDamage = _enemy.weapon != null ? _enemy.weapon.atk : 0;
            damage = _enemy.enemyData.atk + weaponDamage;
            damageType = _enemy.weapon != null ? _enemy.weapon.damageType : DamageType.Chopping;
        }
        
        _damage = damage;
        _weaponDamage = weaponDamage;
        _damageType = damageType;
    }

    private void ApplyDamage()
    {
        if (_currentAttacker == Attacker.Player)
        {
            _enemy.ApplyDamage(_damage);
        }
        else
        {
            _player.ApplyDamage(_damage);
        }
    }

    private void OnBattleEnd()
    {
        // Determine winner and handle end of battle logic
    }
}
