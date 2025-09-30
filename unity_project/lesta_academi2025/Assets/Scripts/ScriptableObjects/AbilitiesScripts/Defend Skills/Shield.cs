using UnityEngine;

/// <summary>
/// Способность "Щит".
/// Для игрока: если сила игрока больше силы врага и уровень достаточен — уменьшает урон на 3 (не менее 0).
/// </summary>
[CreateAssetMenu(fileName = "Shield", menuName = "Abilities/Defend Skills/Shield")]
public class Shield : Abilities
{
    #region Основная логика способности

    /// <summary>
    /// Применяет эффект способности "Щит".
    /// </summary>
    /// <param name="player">Игрок, на которого применяется способность</param>
    /// <param name="enemy">Враг, на которого применяется способность</param>
    /// <param name="steps">Текущий шаг боя</param>
    /// <param name="damage">Урон (по ссылке)</param>
    /// <param name="weaponDamage">Урон оружия (по ссылке)</param>
    /// <param name="damageType">Тип урона</param>
    public override void UseAbility(Player player, Enemy enemy, int steps, ref int damage, ref int weaponDamage, DamageType damageType)
    {
        // Для игрока: проверяем уровень и сравниваем силу
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
        // Для врага: сравниваем ловкость
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

    #endregion
}
