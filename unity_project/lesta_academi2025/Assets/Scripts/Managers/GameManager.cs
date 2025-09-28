using System;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.EventSystems.EventTrigger;

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

    [SerializeField] private GameObject BattleUI;
    [SerializeField] private GameObject RestUI;
    [SerializeField] private GameObject WinUI;
    [SerializeField] private GameObject LooseUI;
    [SerializeField] private GameObject EndUI;

    [SerializeField] private Enemies[] _enemies;

    private GameState _currentState = GameState.Rest;
    public GameState currentState => _currentState;

    private int _battleCount = 0;
    private int _maxBattles = 5;

    private Weapon _weapon;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player.OnDeath += OnPlayerDeath;
        _enemy.OnDeath += OnEnemyDeath;

        GetRandomEnemy();
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

    public void EquipReward()
    {
        WeaponUpgrade?.Invoke(_weapon);
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
            Debug.Log("Battle Start");
            _player.ResetHealth();
            ActiveBattleUI();
            Battle?.Invoke();
        }
        else
        {
            Debug.Log("Rest Start");
            Rest?.Invoke();
        }
    }

    private void ActiveBattleUI()
    {
        RestUI.SetActive(false);
        WinUI.SetActive(false);
        LooseUI.SetActive(false);
        BattleUI.SetActive(true);
    }
    private void ActiveRestUI(GameObject UI)
    {
        BattleUI.SetActive(false);
        UI.SetActive(true);
    }

    private void GetRandomEnemy()
    {
        int index = UnityEngine.Random.Range(0, _enemies.Length);
        EnemyChange?.Invoke(_enemies[index]);
    }

    private void OnEnemyDeath()
    {
        _weapon = _enemy.enemyData.reward;
        GetRandomEnemy();
        GameStateChange();
        ActiveRestUI(WinUI);
        _battleCount++;
        if (_battleCount >= _maxBattles)
        {
            ActiveRestUI(EndUI);
        }
    }

    private void OnPlayerDeath()
    {
        GameStateChange();
        ActiveRestUI(LooseUI);
    }
}
