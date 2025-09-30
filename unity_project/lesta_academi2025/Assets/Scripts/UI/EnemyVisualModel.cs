using System;
using UnityEngine;

/// <summary>
/// Визуальная модель врага. Отвечает за отображение иконки врага на сцене.
/// </summary>
public class EnemyVisualModel : MonoBehaviour
{
    #region Поля

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Enemy _enemy;

    #endregion

    #region Unity Events

    /// <summary>
    /// Подписка на событие смены врага.
    /// </summary>
    private void Start()
    {
        GameManager.Instance.EnemyChange += OnEnemyChange;
    }

    /// <summary>
    /// Проверяет и обновляет иконку врага каждый кадр.
    /// </summary>
    private void Update()
    {
        // Если иконка врага изменилась — обновляем спрайт
        if (_enemy.enemyData.icon != spriteRenderer.sprite)
        {
            spriteRenderer.sprite = _enemy.enemyData.icon;
        }
    }

    #endregion

    #region Обработка событий

    /// <summary>
    /// Обновляет иконку при смене врага через событие GameManager.
    /// </summary>
    /// <param name="enemies">Новые данные врага</param>
    private void OnEnemyChange(Enemies enemies)
    {
        spriteRenderer.sprite = enemies.icon;
    }

    #endregion
}
