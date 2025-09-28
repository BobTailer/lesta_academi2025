using UnityEngine;

[CreateAssetMenu(fileName = "FireBreath", menuName = "Abilities/Battle Skills/FireBreath")]
public class FireBreath : Abilities
{
    public override void UseAbility(Player player, Enemy enemy, int steps, ref int damage, ref int weaponDamage, DamageType damageType)
    {
        if (abilityOwner == AbilityOwner.Player)
        {
            if (requiredLevel <= currentLevel)
            {
                if (steps % 3 == 0)
                {
                    damage += 3;
                    Debug.Log("FireBreath: Damage increased by 3.");
                }
            }
        }
        else
        {
            if (steps % 3 == 0)
            {
                damage += 3;
                Debug.Log("FireBreath: Damage increased by 3.");
            }
        }
    }
}
