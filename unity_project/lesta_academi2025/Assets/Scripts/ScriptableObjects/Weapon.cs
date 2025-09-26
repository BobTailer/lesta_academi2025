using UnityEngine;

public enum WeaponType
{
    Sword,
    Cudgel,
    Dugger,
    Axe,
    Spear,
    LegendarySword
}

public enum  DamageType
{
    Chopping,
    Crushing,
    Pricking
}

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapons")]
public class Weapon : ScriptableObject
{
    public WeaponType weaponType;
    public DamageType damageType;
    public int atk;
}
