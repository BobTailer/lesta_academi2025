using UnityEngine;

[CreateAssetMenu(fileName = "DefencelessCrushing", menuName = "Abilities/Defend Skills/DefencelessCrushing")]
public class DefencelessCrushing : Abilities
{
    public override void UseAbility(Player player, Enemy enemy, int steps, ref int damage, ref int weaponDamage, DamageType damageType)
    {
        if (abilityOwner == AbilityOwner.Player)
        {
            if (requiredLevel <= currentLevel)
            {
                if (damageType == DamageType.Crushing)
                {
                    damage += weaponDamage;
                    weaponDamage *= 2;
                    Debug.Log("DefencelessCrushing: Crushing damage doubled.");
                }
            }
        }
        else
        {
            if (damageType == DamageType.Crushing)
            {
                damage += weaponDamage;
                weaponDamage *= 2;
                Debug.Log("DefencelessCrushing: Crushing damage doubled.");
            }
        }
    }
}
