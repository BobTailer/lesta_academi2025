using UnityEngine;

[CreateAssetMenu(fileName = "PowerUpgrade", menuName = "Abilities/Upgrade Skills/PowerUpgrade")]
public class PowerUpgrade : Abilities
{
    public override void UseAbility(Player player, Enemy enemy, int steps, ref int damage, ref int weaponDamage, DamageType damageType)
    {
        if (requiredLevel == currentLevel)
        {
            player.UpgradeStats(1, 0, 0);
            Debug.Log("PowerUpgrade: Power increased by 1.");
        }
    }
}
