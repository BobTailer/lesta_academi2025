using UnityEngine;

[CreateAssetMenu(fileName = "Shield", menuName = "Abilities/Defend Skills/Shield")]
public class Shield : Abilities
{
    public override void UseAbility(Player player, Enemy enemy, int steps, ref int damage, ref int weaponDamage, DamageType damageType)
    {
        if (abilityOwner == AbilityOwner.Player)
        {
            if (requiredLevel <= currentLevel)
            {
                if (player.power > enemy.enemyData.power)
                {
                    damage -= 3;
                    if (damage < 0) damage = 0;
                    Debug.Log("Shield: Damage reduced by 3.");
                }
            }
        }
        else
        {
            if (player.agility < enemy.enemyData.agility)
            {
                damage -= 3;
                if (damage < 0) damage = 0;
                Debug.Log("Shield: Damage reduced by 3.");
            }
        }
    }
}
