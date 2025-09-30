using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Типы способностей: урон, защита, усиление характеристик.
/// </summary>
public enum AbilityType
{
    Damage,
    Defend,
    StatBoost
}

/// <summary>
/// Владение способностью: игрок или враг.
/// </summary>
public enum AbilityOwner
{     
    Player,
    Enemy
}

/// <summary>
/// Абстрактный базовый класс для всех способностей.
/// </summary>
public abstract class Abilities : ScriptableObject
{
    #region Основные параметры способности

    /// <summary>Требуемый уровень для активации способности.</summary>
    public int requiredLevel;

    /// <summary>Текущий уровень владельца способности.</summary>
    public int currentLevel;

    /// <summary>Тип способности.</summary>
    public AbilityType abilityType;

    /// <summary>Владелец способности (игрок или враг).</summary>
    public AbilityOwner abilityOwner;

    /// <summary>Название способности.</summary>
    public string abilityName;

    /// <summary>Описание способности.</summary>
    public string abilityDescription;

    #endregion

    #region Основная логика способности

    /// <summary>
    /// Абстрактный метод применения способности.
    /// </summary>
    /// <param name="player">Игрок, на которого применяется способность</param>
    /// <param name="enemy">Враг, на которого применяется способность</param>
    /// <param name="steps">Текущий шаг боя</param>
    /// <param name="damage">Урон (по ссылке)</param>
    /// <param name="weaponDamage">Урон оружия (по ссылке)</param>
    /// <param name="damageType">Тип урона</param>
    public abstract void UseAbility(Player player, Enemy enemy, int steps, ref int damage, ref int weaponDamage, DamageType damageType);

    #endregion
}
