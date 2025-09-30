using System;
using System.Collections;
using UnityEngine;

public class Enemy : Entity
{
    #region Поля и свойства

    private Enemies _enemyData;
    public Enemies enemyData => _enemyData;

    private Weapon _weapon;
    public Weapon weapon => _weapon;

    public Action OnDeath;
    public Action OnDeathDelayStart;

    private AudioSource _audioSource;

    #endregion

    #region Unity Events

    private void Awake()
    {
        GameManager.Instance.EnemyChange += OnEnemyChange;
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnDestroy()
    {
        OnDeath = null;
        OnDeathDelayStart = null;
    }

    #endregion

    #region Основные методы

    /// <summary>
    /// Обновляет данные врага при смене.
    /// </summary>
    public void OnEnemyChange(Enemies enemyData)
    {
        _enemyData = enemyData;
        _maxHP = _enemyData.hp;
        _currentHP = _enemyData.hp;
    }

    /// <summary>
    /// Применяет урон врагу.
    /// </summary>
    public void ApplyDamage(int damage)
    {
        Debug.Log($"Enemy takes {damage} damage");
        _currentHP -= damage;

        if (_currentHP <= 0)
        {
            _currentHP = 0;
            Debug.Log("Enemy defeated!");
            _audioSource.Play();
            OnDeathDelayStart?.Invoke(); // Сообщаем о начале задержки
            StartCoroutine(DeathDelayCoroutine());
        }

        Debug.Log($"Enemy HP: {_currentHP}/{_enemyData.hp}");
    }

    /// <summary>
    /// Корутина задержки перед событием смерти.
    /// </summary>
    private IEnumerator DeathDelayCoroutine()
    {
        yield return new WaitForSeconds(3f);
        OnDeath?.Invoke();
    }

    #endregion
}
