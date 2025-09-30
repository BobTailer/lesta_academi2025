using System;
using UnityEngine;

/// <summary>
/// ���������� ������ �����. �������� �� ����������� ������ ����� �� �����.
/// </summary>
public class EnemyVisualModel : MonoBehaviour
{
    #region ����

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Enemy _enemy;

    #endregion

    #region Unity Events

    /// <summary>
    /// �������� �� ������� ����� �����.
    /// </summary>
    private void Start()
    {
        GameManager.Instance.EnemyChange += OnEnemyChange;
    }

    /// <summary>
    /// ��������� � ��������� ������ ����� ������ ����.
    /// </summary>
    private void Update()
    {
        // ���� ������ ����� ���������� � ��������� ������
        if (_enemy.enemyData.icon != spriteRenderer.sprite)
        {
            spriteRenderer.sprite = _enemy.enemyData.icon;
        }
    }

    #endregion

    #region ��������� �������

    /// <summary>
    /// ��������� ������ ��� ����� ����� ����� ������� GameManager.
    /// </summary>
    /// <param name="enemies">����� ������ �����</param>
    private void OnEnemyChange(Enemies enemies)
    {
        spriteRenderer.sprite = enemies.icon;
    }

    #endregion
}
