using UnityEngine;

[CreateAssetMenu(fileName = "StealthAttack", menuName = "Abilities/Battle Skills/StealthAttack")]
public class StealthAttack : Abilities
{
    public override void UseAbility(Player player, Enemy enemy, int steps, ref int damage, ref int weaponDamage, DamageType damageType)
    {
        if (abilityOwner == AbilityOwner.Player)
        {
            if (requiredLevel <= currentLevel)
            {
                if (player.agility > enemy.enemyData.agility)
                {
                    Debug.Log("Stealth Attack: Player's agility is higher than Enemy's. Increasing damage by 1.");
                    damage += 1;
                }
            }
        }
        else
        {
            if (player.agility < enemy.enemyData.agility)
            {
                Debug.Log("Stealth Attack: Enemy's agility is higher than Player's. Increasing damage by 1.");
                damage += 1;
            }
        }
    }
}
