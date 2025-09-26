using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Enemies _enemyData;
    public Enemies enemyData => _enemyData;

    private Weapon _weapon;
    public Weapon weapon => _weapon;

    private int _currentHp;

    public Action OnDeath;

    private void Awake()
    {
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Instance.EnemyChange += OnEnemyChange;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnEnemyChange(Enemies enemyData)
    {
        _enemyData = enemyData;
        _currentHp = _enemyData.hp;
    }

    public void ApplyDamage(int damage)
    {
        _currentHp -= damage;
        if (_currentHp <= 0)
        {
            OnDeath?.Invoke();
        }
    }

    private void OnDestroy()
    {
        OnDeath = null;
    }
}
