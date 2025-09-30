    using UnityEngine;

/// <summary>
/// ������������ ����� ������.
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
/// ������������ ����� �����.
/// </summary>
public enum DamageType
{
    Chopping,
    Crushing,
    Pricking
}

/// <summary>
/// ScriptableObject ��� �������� ������ �� ������.
/// </summary>
[CreateAssetMenu(fileName = "Weapon", menuName = "Weapons")]
public class Weapon : ScriptableObject
{
    #region �������� ��������� ������

    /// <summary>��� ������.</summary>
    public WeaponType weaponType;

    /// <summary>��� �����, ���������� �������.</summary>
    public DamageType damageType;

    /// <summary>������� ����� ������.</summary>
    public int atk;

    /// <summary>��������� ������������� ���� ����� (��� UI).</summary>
    public string damageTypeString;

    /// <summary>�������� ������.</summary>
    public string weaponName;

    /// <summary>������ ������.</summary>
    public Sprite icon;

    #endregion
}
