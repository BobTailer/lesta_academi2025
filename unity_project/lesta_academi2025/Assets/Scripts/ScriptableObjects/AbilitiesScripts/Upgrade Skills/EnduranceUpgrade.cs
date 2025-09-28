using UnityEngine;

[CreateAssetMenu(fileName = "EnduranceUpgrade", menuName = "Abilities/Upgrade Skills/EnduranceUpgrade")]
public class EnduranceUpgrade : Abilities
{
    public override void UseAbility(Player player, Enemy enemy, int steps, ref int damage, ref int weaponDamage, DamageType damageType)
    {
        if (requiredLevel == currentLevel)
        {
            player.UpgradeStats(0, 0, 1);
            Debug.Log("EnduranceUpgrade: Endurance increased by 1.");
        }
    }
}
