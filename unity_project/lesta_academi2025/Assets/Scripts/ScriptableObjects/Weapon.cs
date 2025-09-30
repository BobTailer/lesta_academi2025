    using UnityEngine;

/// <summary>
/// Перечисление типов оружия.
/// </summary>
public enum WeaponType
{
    Sword,
    Cudgel,
    Dugger,
    Axe,
    Spear,
    LegendarySword
}

/// <summary>
/// Перечисление типов урона.
/// </summary>
public enum DamageType
{
    Chopping,
    Crushing,
    Pricking
}

/// <summary>
/// ScriptableObject для хранения данных об оружии.
/// </summary>
[CreateAssetMenu(fileName = "Weapon", menuName = "Weapons")]
public class Weapon : ScriptableObject
{
    #region Основные параметры оружия

    /// <summary>Тип оружия.</summary>
    public WeaponType weaponType;

    /// <summary>Тип урона, наносимого оружием.</summary>
    public DamageType damageType;

    /// <summary>Базовая атака оружия.</summary>
    public int atk;

    /// <summary>Строковое представление типа урона (для UI).</summary>
    public string damageTypeString;

    /// <summary>Название оружия.</summary>
    public string weaponName;

    /// <summary>Иконка оружия.</summary>
    public Sprite icon;

    #endregion
}
