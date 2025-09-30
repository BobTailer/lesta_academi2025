using System;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.EventSystems.EventTrigger;

public enum GameState
{
    Rest,
    Battle
}

/// <summary>
/// Главный менеджер игры. Управляет состояниями, событиями, сменой врагов и наградами.
/// </summary>
public class GameManager : Singleton<GameManager>
{
    #region События

    public Action<Characters> LevelUpgrade;
    public Action<Weapon> WeaponUpgrade;
    public Action<Enemies> EnemyChange;
    public Action Battle;
    public Action Rest;
    public Action AfterEnemyDeath;
    public Action AfterPlayerDeath;
    public Action OnGameOver;

    #endregion

    #region Поля и свойства

    [SerializeField] private Player _player;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Enemies[] _enemies;

    private GameState _currentState = GameState.Rest;
    public GameState currentState => _currentState;

    private int _battleCount = 0;
    private int _maxBattles = 5;
    public int battleCount => _battleCount;
    public int maxBattles => _maxBattles;

    private Weapon _weapon;
    public Weapon weapon => _weapon;

    #endregion

    #region Unity Events

    private void Start()
    {
        _player.OnDeath += OnPlayerDeath;
        _enemy.OnDeath += OnEnemyDeath;
        GetRandomEnemy();
    }

    private void OnDestroy()
    {
        LevelUpgrade = null;
        WeaponUpgrade = null;
        EnemyChange = null;
        Battle = null;
        Rest = null;
        AfterEnemyDeath = null;
        AfterPlayerDeath = null;
        OnGameOver = null;
    }

    #endregion

    #region Основная логика

    /// <summary>
    /// Вызывается при апгрейде уровня персонажа.
    /// </summary>
    public void OnLevelUpgrade(Characters character)
    {
        LevelUpgrade?.Invoke(character);
    }

    /// <summary>
    /// Вызывается при апгрейде оружия.
    /// </summary>
    public void OnWeaponUpgrade(Weapon weapon)
    {
        if (_player.weapon == null)
            WeaponUpgrade?.Invoke(weapon);
    }

    /// <summary>
    /// Выдать награду игроку.
    /// </summary>
    public void EquipReward()
    {
        WeaponUpgrade?.Invoke(_weapon);
    }

    /// <summary>
    /// Смена текущего врага.
    /// </summary>
    public void OnEnemyChange(Enemies enemy)
    {
        EnemyChange?.Invoke(enemy);
    }

    /// <summary>
    /// Переключение состояния игры (Бой/Отдых).
    /// </summary>
    public void GameStateChange()
    {
        _currentState = _currentState == GameState.Rest ? GameState.Battle : GameState.Rest;
        if (_currentState == GameState.Battle)
        {
            Debug.Log("Battle Start");
            _player.ResetHealth();
            Battle?.Invoke();
        }
        else
        {
            Debug.Log("Rest Start");
            Rest?.Invoke();
        }
    }

    /// <summary>
    /// Получить случайного врага из списка.
    /// </summary>
    private void GetRandomEnemy()
    {
        int index = UnityEngine.Random.Range(0, _enemies.Length);
        EnemyChange?.Invoke(_enemies[index]);
    }

    /// <summary>
    /// Обработка смерти врага.
    /// </summary>
    private void OnEnemyDeath()
    {
        _weapon = _enemy.enemyData.reward;
        GetRandomEnemy();
        GameStateChange();
        _battleCount++;
        if (_battleCount >= _maxBattles)
        {
            OnGameOver?.Invoke();
        }
        else
        {
            AfterEnemyDeath?.Invoke();
        }
    }

    /// <summary>
    /// Обработка смерти игрока.
    /// </summary>
    private void OnPlayerDeath()
    {
        GameStateChange();
        AfterPlayerDeath?.Invoke();
    }

    #endregion
}
