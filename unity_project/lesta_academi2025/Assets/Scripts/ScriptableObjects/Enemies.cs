using UnityEngine;

/// <summary>
/// Перечисление типов врагов.
/// </summary>
public enum EnemyType
{
    Goblin,
    Skeleton,
    Slime,
    Ghost,
    Golem,
    Dragon
}

/// <summary>
/// ScriptableObject для хранения данных врага.
/// </summary>
[CreateAssetMenu(fileName = "Enemy", menuName = "Enemies")]
public class Enemies : ScriptableObject
{
    #region Основные параметры врага

    /// <summary>Тип врага.</summary>
    public EnemyType enemyType;

    /// <summary>Очки здоровья врага.</summary>
    public int hp;

    /// <summary>Базовая атака врага.</summary>
    public int atk;

    /// <summary>Сила врага.</summary>
    public int power;

    /// <summary>Ловкость врага.</summary>
    public int agility;

    /// <summary>Выносливость врага.</summary>
    public int endurance;

    /// <summary>Иконка врага.</summary>
    public Sprite icon;

    /// <summary>Имя врага.</summary>
    public string enemyName;

    /// <summary>Награда за победу над врагом (оружие).</summary>
    public Weapon reward;

    /// <summary>Способность врага.</summary>
    public Abilities ability;

    #endregion
}
