using UnityEngine;

[CreateAssetMenu(fileName = "AgilityUpgrade", menuName = "Abilities/Upgrade Skills/AgilityUpgrade")]
public class AgilityUpgrade : Abilities
{
    public override void UseAbility(Player player, Enemy enemy, int steps, ref int damage, ref int weaponDamage, DamageType damageType)
    {
        if (requiredLevel == currentLevel)
        {
            player.UpgradeStats(0, 1, 0);
            Debug.Log("AgilityUpgrade: Agility increased by 1.");
        }
    }
}
