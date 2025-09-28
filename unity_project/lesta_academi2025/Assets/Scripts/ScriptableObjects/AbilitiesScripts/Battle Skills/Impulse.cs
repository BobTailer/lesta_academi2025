using UnityEngine;

[CreateAssetMenu(fileName = "Impulse", menuName = "Abilities/Battle Skills/Impulse")]
public class Impulse : Abilities
{
    public override void UseAbility(Player player, Enemy enemy, int steps, ref int damage, ref int weaponDamage, DamageType damageType)
    {
        if (abilityOwner == AbilityOwner.Player)
        {
            if (requiredLevel <= currentLevel)
            {
                if (steps == 1)
                {
                    damage += weaponDamage;
                    weaponDamage *= 2;
                    Debug.Log("Impulse: Damage increased by weapon damage and weapon damage doubled.");
                }
            }
        }
        else
        {
            if (steps == 1)
            {
                damage += weaponDamage;
                weaponDamage *= 2;
                Debug.Log("Impulse: Damage increased by weapon damage and weapon damage doubled.");
            }
        }
    }
}
