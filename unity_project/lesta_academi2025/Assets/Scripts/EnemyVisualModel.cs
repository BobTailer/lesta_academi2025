using System;
using UnityEngine;

public class EnemyVisualModel : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Enemy _enemy;

    private void Start()
    {
        GameManager.Instance.EnemyChange += OnEnemyChange;
    }

    private void Update()
    {
        if (_enemy.enemyData.icon != spriteRenderer.sprite)
        {
            spriteRenderer.sprite = _enemy.enemyData.icon;
        }
    }

    private void OnEnemyChange(Enemies enemies)
    {
        spriteRenderer.sprite = enemies.icon;
    }
}
