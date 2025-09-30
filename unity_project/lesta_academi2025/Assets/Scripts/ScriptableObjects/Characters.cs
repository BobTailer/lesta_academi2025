using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Перечисление типов персонажей.
/// </summary>
public enum CharacterType
{
    Bandit,
    Warrior,
    Barbarian
}

/// <summary>
/// ScriptableObject для хранения данных персонажа.
/// </summary>
[CreateAssetMenu(fileName = "Character", menuName = "Characters")]
public class Characters : ScriptableObject
{
    #region Основные параметры персонажа

    /// <summary>Тип персонажа.</summary>
    public CharacterType character;

    /// <summary>Оружие персонажа.</summary>
    public Weapon weapon;

    /// <summary>Количество HP, добавляемое за уровень.</summary>
    public int HpPerLevel;

    /// <summary>Текущий уровень персонажа.</summary>
    public int level;

    /// <summary>Массив способностей персонажа.</summary>
    public Abilities[] abilities;

    /// <summary>Имя персонажа.</summary>
    public string characterName;

    /// <summary>Иконка персонажа.</summary>
    public Sprite icon;

    #endregion

    #region Методы

    /// <summary>
    /// Сбросить уровень персонажа к начальному значению.
    /// </summary>
    public void ResetLevel()
    {
        level = 0;
    }

    #endregion
}
