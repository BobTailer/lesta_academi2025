using UnityEngine;

[CreateAssetMenu(fileName = "Rage", menuName = "Abilities/Battle Skills/Rage")]
public class Rage : Abilities
{
    public override void UseAbility(Player player, Enemy enemy, int steps, ref int damage, ref int weaponDamage, DamageType damageType)
    {
        if (abilityOwner == AbilityOwner.Player)
        {
            if (requiredLevel <= currentLevel)
            {
                if (steps < 4)
                {
                    damage += 2;
                    Debug.Log("Rage: Damage increased by 2.");
                }
                else
                {
                    damage -= 1;
                    Debug.Log("Rage: Damage decreased by 1.");
                }
            }
        }
        else
        {
            if (steps > 1)
            {
                if (steps < 4)
                {
                    damage += 2;
                    Debug.Log("Rage: Damage increased by 2.");
                }
                else
                {
                    damage -= 1;
                    Debug.Log("Rage: Damage decreased by 1.");
                }
            }
        }
    }
}
