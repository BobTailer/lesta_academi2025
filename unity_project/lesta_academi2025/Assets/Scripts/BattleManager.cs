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
        yield return new WaitForSeconds(5f); // Пауза 5 секунда

        if (AttackChance())
        {
            CalculateDamage();
            //Debug.Log($"{_currentAttacker} hits for {_damage} damage (Weapon Damage: {_weaponDamage}, Damage Type: {_damageType})");
            ApplyDamage();
        }
        else
        {
            //Debug.Log($"{_currentAttacker} misses!");
        }
        // Switch turns
        _currentAttacker = _currentAttacker == Attacker.Player ? Attacker.Enemy : Attacker.Player;
        _steps++;
        //Debug.Log($"Step {_steps} completed. Next attacker: {_currentAttacker}");

        _battleRoutineRunning = false;
    }

    private void OnBattleStart()
    {
        _steps = 0;
        //Debug.Log("Расчет ловкости");
        if (_player.agility >= _enemy.enemyData.agility)
        {
            //Debug.Log("Игрок атакует первым");
            // Player attacks first
            _currentAttacker = Attacker.Player;
        }
        else
        {
            //Debug.Log("Враг атакует первым");
            // Enemy attacks first
            _currentAttacker = Attacker.Enemy;
        }
    }

    private bool AttackChance()
    {
        //Debug.Log("Расчет шанса атаки");
        var general_agility = _player.agility + _enemy.enemyData.agility;
        var chance = Random.Range(1, general_agility + 1);
        if (_currentAttacker == Attacker.Player)
        {
            //Debug.Log($"Шанс атаки игрока: {chance} против {_enemy.enemyData.agility} - {chance > _enemy.enemyData.agility}");
            return chance > _enemy.enemyData.agility;
        }
        else
        {
            //Debug.Log($"Шанс атаки врага: {chance} против {_player.agility} - {chance > _player.agility}");
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
            //Debug.Log("Расчет урона игрока");
            weaponDamage = _player.weapon != null ? _player.weapon.atk : 0;
            damage = _player.power + weaponDamage;
            damageType = _player.weapon != null ? _player.weapon.damageType : DamageType.Chopping;
        }
        else
        {
            //Debug.Log("Расчет урона врага");
            weaponDamage = _enemy.enemyData.atk;
            damage = _enemy.enemyData.power + weaponDamage;
            damageType = _enemy.weapon != null ? _enemy.weapon.damageType : DamageType.Chopping;
        }
        
        _damage = damage;
        _weaponDamage = weaponDamage;
        _damageType = damageType;
        //Debug.Log($"Урон рассчитан: {_damage} (Урон оружия: {_weaponDamage}, Тип урона: {_damageType})");
    }

    private void ApplyDamage()
    {
        //Debug.Log("Применение урона");
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
