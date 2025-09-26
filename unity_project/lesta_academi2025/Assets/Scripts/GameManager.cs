using System;
using UnityEngine;

public enum GameState
{
    Rest,
    Battle
}

public class GameManager : Singleton<GameManager>
{
    public Action<Characters> LevelUpgrade;
    public Action<Weapon> WeaponUpgrade;
    public Action<Enemies> EnemyChange;
    public Action Battle;
    public Action Rest;

    [SerializeField] private Player _player;
    [SerializeField] private Enemy _enemy;

    private GameState _currentState = GameState.Rest;
    public GameState currentState => _currentState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player.OnDeath += GameStateChange;
        _enemy.OnDeath += GameStateChange;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        LevelUpgrade = null;
        WeaponUpgrade = null;
        EnemyChange = null;
        Battle = null;
        Rest = null;
    }

    public void OnLevelUpgrade(Characters character)
    {
        LevelUpgrade?.Invoke(character);
    }
    public void OnWeaponUpgrade(Weapon weapon)
    {
        WeaponUpgrade?.Invoke(weapon);
    }
    public void OnEnemyChange(Enemies enemy)
    {
        EnemyChange?.Invoke(enemy);
    }

    public void GameStateChange()
    {
        _currentState = _currentState == GameState.Rest ? GameState.Battle : GameState.Rest;
        if (_currentState == GameState.Battle)
        {
            Battle?.Invoke();
        }
        else
        {
            Rest?.Invoke();
        }
    }
}
