using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public enum Attacker
{
    Player,
    Enemy
}

public class BattleManager : Singleton<BattleManager>
{
    public Action<Abilities, Characters, int> OnPlayerAbilityUsed;
    public Action<Abilities, Enemies, int> OnEnemyAbilityUsed;
    public Action<int, Attacker> OnHit;
    public Action<Attacker> OnMiss;
    public Action OnSwitch;

    private Attacker _currentAttacker = Attacker.Player;
    public Attacker currentAttacker => _currentAttacker;

    private int _steps;
    public int steps => _steps;

    [SerializeField] private AudioResource _attackSound;
    [SerializeField] private AudioResource _missSource;

    [SerializeField] private Player _player;
    [SerializeField] private Enemy _enemy;

    private int _damage;
    private int _weaponDamage;
    private DamageType _damageType;

    private bool _battleRoutineRunning = false;

    private bool _isBattlePaused = false;

    private int _roundAttackCount = 0;

    private AudioSource _audioSource;

    private void Start()
    {
        GameManager.Instance.Battle += OnBattleStart;
        _player.OnDeathDelayStart += PauseBattle;
        _enemy.OnDeathDelayStart += PauseBattle;
        _player.OnDeath += ResumeBattle;
        _enemy.OnDeath += ResumeBattle;

        _audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.currentState == GameState.Battle && !_battleRoutineRunning && !_isBattlePaused)
        {
            StartCoroutine(BattleRoutine());
        }
    }

    private IEnumerator BattleRoutine()
    {
        _battleRoutineRunning = true;
        yield return new WaitForSeconds(2f);

        if (AttackChance())
        {
            CalculateDamage();
            Debug.Log($"{_currentAttacker} hits for {_damage} damage (Weapon Damage: {_weaponDamage}, Damage Type: {_damageType})");
            ApplyDamage();
            _audioSource.resource = _attackSound;
            _audioSource.Play();
        }
        else
        {
            Debug.Log($"{_currentAttacker} misses!");
            OnMiss?.Invoke(_currentAttacker);
            _audioSource.resource = _missSource;
            _audioSource.Play();
        }

        yield return new WaitForSeconds(5f);
        // Переключаем атакующего
        _currentAttacker = _currentAttacker == Attacker.Player ? Attacker.Enemy : Attacker.Player;
        OnSwitch?.Invoke();

        // Увеличиваем счётчик атак в круге
        _roundAttackCount++;

        // Если оба атаковали — увеличиваем шаг и сбрасываем счётчик
        if (_roundAttackCount >= 2)
        {
            Debug.Log($"Step {_steps} completed. Next attacker: {_currentAttacker}");
            _steps++;
            _roundAttackCount = 0;
        }

        _battleRoutineRunning = false;
    }

    private void OnBattleStart()
    {
        _steps = 1;
        _roundAttackCount = 0;
        Debug.Log("Расчет ловкости");
        if (_player.agility >= _enemy.enemyData.agility)
        {
            Debug.Log("Игрок атакует первым");
            // Player attacks first
            _currentAttacker = Attacker.Player;
        }
        else
        {
            Debug.Log("Враг атакует первым");
            // Enemy attacks first
            _currentAttacker = Attacker.Enemy;
        }
    }

    private bool AttackChance()
    {
        Debug.Log("Расчет шанса атаки");
        var general_agility = _player.agility + _enemy.enemyData.agility;
        var chance = UnityEngine.Random.Range(1, general_agility + 1);
        if (_currentAttacker == Attacker.Player)
        {
            Debug.Log($"Шанс атаки игрока: {chance} против {_enemy.enemyData.agility} - {chance > _enemy.enemyData.agility}");
            return chance > _enemy.enemyData.agility;
        }
        else
        {
            Debug.Log($"Шанс атаки врага: {chance} против {_player.agility} - {chance > _player.agility}");
            return chance > _player.agility;
        }
    }

    private void CalculateDamage()
    {
        _damage = 0;
        _weaponDamage = 0;
        _damageType = DamageType.Chopping;

        if (_currentAttacker == Attacker.Player)
        {
            Debug.Log("Расчет урона игрока");
            _weaponDamage = _player.weapon != null ? _player.weapon.atk : 0;
            _damage = _player.power + _weaponDamage;
            _damageType = _player.weapon != null ? _player.weapon.damageType : DamageType.Chopping;

            Debug.Log($"Базовый урон игрока: {_damage} (Урон оружия: {_weaponDamage}, Тип урона: {_damageType})");

            // Применение атакующей способностей игрока
            foreach (var character in _player.squad)
            {
                foreach (var ability in character.abilities)
                {
                    if (ability.abilityType == AbilityType.Damage)
                    {
                        var dmgBefore = _damage;
                        ability.UseAbility(_player, _enemy, _steps, ref _damage, ref _weaponDamage, _damageType);
                        if (dmgBefore != _damage)
                        {
                            OnPlayerAbilityUsed?.Invoke(ability, character, _damage - dmgBefore);
                        }
                    }
                }
            }

            Debug.Log($"Урон после атакующих способностей игрока: {_damage} (Урон оружия: {_weaponDamage}, Тип урона: {_damageType})");

            // Применение защитной способности врага
            if (_enemy.enemyData.ability != null)
            {
                if (_enemy.enemyData.ability.abilityType == AbilityType.Defend)
                {
                    var dmgBefore = _damage;
                    _enemy.enemyData.ability.UseAbility(_player, _enemy, _steps, ref _damage, ref _weaponDamage, _damageType);
                    if (dmgBefore != _damage)
                    {
                        OnEnemyAbilityUsed?.Invoke(_enemy.enemyData.ability, _enemy.enemyData, _damage - dmgBefore);
                    }
                }
            }
        }
        else
        {
            Debug.Log("Расчет урона врага");
            _weaponDamage = _enemy.enemyData.atk;
            _damage = _enemy.enemyData.power + _weaponDamage;
            _damageType = _enemy.weapon != null ? _enemy.weapon.damageType : DamageType.Chopping;

            // Применение способностей врага
            if (_enemy.enemyData.ability != null)
            {
                if (_enemy.enemyData.ability.abilityType == AbilityType.Damage)
                {
                    var dmgBefore = _damage;
                    _enemy.enemyData.ability.UseAbility(_player, _enemy, _steps, ref _damage, ref _weaponDamage, _damageType);
                    if (dmgBefore != _damage)
                    {
                        OnEnemyAbilityUsed?.Invoke(_enemy.enemyData.ability, _enemy.enemyData, _damage - dmgBefore);
                    }
                }
            }

            // Применение защитных способностей игрока
            foreach (var character in _player.squad)
            {
                foreach (var ability in character.abilities)
                {
                    if (ability.abilityType == AbilityType.Defend)
                    {
                        var dmgBefore = _damage;
                        ability.UseAbility(_player, _enemy, _steps, ref _damage, ref _weaponDamage, _damageType);
                        if (dmgBefore != _damage)
                        {
                            OnPlayerAbilityUsed?.Invoke(ability, character, _damage - dmgBefore);
                        }
                    }
                }
            }
        }
        Debug.Log($"Урон рассчитан: {_damage} (Урон оружия: {_weaponDamage}, Тип урона: {_damageType})");
    }

    private void ApplyDamage()
    {
        Debug.Log("Применение урона");
        if (_currentAttacker == Attacker.Player)
        {
            _enemy.ApplyDamage(_damage);
        }
        else
        {
            _player.ApplyDamage(_damage);
        }
        OnHit?.Invoke(_damage, _currentAttacker);
    }

    private void OnBattleEnd()
    {
        // Determine winner and handle end of battle logic
    }

    private void PauseBattle()
    {
        _isBattlePaused = true;
    }

    private void ResumeBattle()
    {
        _isBattlePaused = false;
    }

    private void OnDestroy()
    {
        OnPlayerAbilityUsed = null;
        OnEnemyAbilityUsed = null;
        OnHit = null;
        OnMiss = null;
        OnSwitch = null;
    }
}
