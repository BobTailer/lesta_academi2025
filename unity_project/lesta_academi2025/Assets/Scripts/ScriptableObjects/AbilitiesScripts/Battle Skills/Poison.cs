using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

[CreateAssetMenu(fileName = "Poison", menuName = "Abilities/Battle Skills/Poison")]
public class Poison : Abilities
{
    public override void UseAbility(Player player, Enemy enemy, int steps, ref int damage, ref int weaponDamage, DamageType damageType)
    {
        if (abilityOwner == AbilityOwner.Player)
        {
            if (requiredLevel <= currentLevel)
            {
                if (steps > 1)
                {
                    damage += steps - 1;
                    Debug.Log("Poison: Damage increased by " + (steps - 1) + ".");
                }
            }
        }
        else
        {
            if (steps > 1)
            {
                damage += steps - 1;
                Debug.Log("Poison: Damage increased by " + (steps - 1) + ".");
            }
        }
    }
}
