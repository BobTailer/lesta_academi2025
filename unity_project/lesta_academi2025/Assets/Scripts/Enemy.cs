using System;
using System.Collections;
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
        _currentHp = _enemyData.hp;
    }

    public void ApplyDamage(int damage)
    {
        //Debug.Log($"Enemy takes {damage} damage");
        _currentHp -= damage;
        if (_currentHp <= 0)
        {
            //Debug.Log("Enemy defeated!");
            StartCoroutine(DeathDelayCoroutine());
        }
        //Debug.Log($"Enemy HP: {_currentHp}/{_enemyData.hp}");
    }

    private IEnumerator DeathDelayCoroutine()
    {
        yield return new WaitForSeconds(3f);
        OnDeath?.Invoke();
    }

    private void OnDestroy()
    {
        OnDeath = null;
    }
}
