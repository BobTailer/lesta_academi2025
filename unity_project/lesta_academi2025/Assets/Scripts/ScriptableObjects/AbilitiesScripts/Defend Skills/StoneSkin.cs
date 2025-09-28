using UnityEngine;

[CreateAssetMenu(fileName = "StoneSkin", menuName = "Abilities/Defend Skills/StoneSkin")] 
public class StoneSkin : Abilities
{
    public override void UseAbility(Player player, Enemy enemy, int steps, ref int damage, ref int weaponDamage, DamageType damageType)
    {
        if (abilityOwner == AbilityOwner.Player)
        {
            if (requiredLevel <= currentLevel)
            {
                damage -= player.endurance;
                Debug.Log("Stone Skin: Damage reduced by endurance.");
            }
        }
        else
        {
            damage -= enemy.enemyData.endurance;
            Debug.Log("Stone Skin: Damage reduced by endurance.");
        }
    }
}
