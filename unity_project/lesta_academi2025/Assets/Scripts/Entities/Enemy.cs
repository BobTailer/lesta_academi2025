using System;
using System.Collections;
using UnityEngine;

public class Enemy : Entity
{
    private Enemies _enemyData;
    public Enemies enemyData => _enemyData;

    private Weapon _weapon;
    public Weapon weapon => _weapon;

    public Action OnDeath;

    public Action OnDeathDelayStart;

    private void Awake()
    {
        GameManager.Instance.EnemyChange += OnEnemyChange;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnEnemyChange(Enemies enemyData)
    {
        _enemyData = enemyData;
        _maxHP = _enemyData.hp;
        _currentHP = _enemyData.hp;
    }

    public void ApplyDamage(int damage)
    {
        Debug.Log($"Enemy takes {damage} damage");
        _currentHP -= damage;
        if (_currentHP <= 0)
        {
            _currentHP = 0;
            Debug.Log("Enemy defeated!");
            OnDeathDelayStart?.Invoke(); // Сообщаем о начале задержки
            StartCoroutine(DeathDelayCoroutine());
        }
        Debug.Log($"Enemy HP: {_currentHP}/{_enemyData.hp}");
    }

    private IEnumerator DeathDelayCoroutine()
    {
        yield return new WaitForSeconds(3f);
        OnDeath?.Invoke();
    }

    private void OnDestroy()
    {
        OnDeath = null;
        OnDeathDelayStart = null;
    }
}
