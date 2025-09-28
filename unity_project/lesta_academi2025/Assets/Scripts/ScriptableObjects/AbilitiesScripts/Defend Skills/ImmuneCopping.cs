using UnityEngine;

[CreateAssetMenu(fileName = "ImmuneCopping", menuName = "Abilities/Defend Skills/ImmuneCopping")]
public class ImmuneCopping : Abilities
{
    public override void UseAbility(Player player, Enemy enemy, int steps, ref int damage, ref int weaponDamage, DamageType damageType)
    {
        if (abilityOwner == AbilityOwner.Player)
        {
            if (requiredLevel <= currentLevel)
            {
                if (damageType == DamageType.Chopping)
                {
                    damage -= weaponDamage;
                    weaponDamage = 0;
                    Debug.Log("ImmuneCopping: Chopping damage nullified.");
                }
            }
        }
        else
        {
            if (damageType == DamageType.Chopping)
            {
                damage -= weaponDamage;
                weaponDamage = 0;
                Debug.Log("ImmuneCopping: Chopping damage nullified.");
            }
        }
    }
}
