using UnityEngine;
using UnityEngine.UI;

public enum AbilityType
{
    Damage,
    Defend,
    StatBoost
}

public enum AbilityOwner
{     
    Player,
    Enemy
}

public abstract class Abilities : ScriptableObject
{
    public int requiredLevel;
    public int currentLevel;
    public AbilityType abilityType;
    public AbilityOwner abilityOwner;

    public string abilityName;
    public string abilityDescription;

    public abstract void UseAbility(Player player, Enemy enemy, int steps, ref int damage, ref int weaponDamage, DamageType damageType);

}
