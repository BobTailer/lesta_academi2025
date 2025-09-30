using UnityEngine;

/// <summary>
/// Способность "Атака из тени".
/// Для игрока: если ловкость игрока выше ловкости врага — увеличивает урон на 1.
/// Для врага: если ловкость врага выше ловкости игрока — увеличивает урон на 1.
/// </summary>
[CreateAssetMenu(fileName = "StealthAttack", menuName = "Abilities/Battle Skills/StealthAttack")]
public class StealthAttack : Abilities
{
    #region Основная логика способности

    /// <summary>
    /// Применяет эффект способности "Атака из тени".
    /// </summary>
    /// <param name="player">Игрок, на которого применяется способность</param>
    /// <param name="enemy">Враг, на которого применяется способность</param>
    /// <param name="steps">Текущий шаг боя</param>
    /// <param name="damage">Урон (по ссылке)</param>
    /// <param name="weaponDamage">Урон оружия (по ссылке)</param>
    /// <param name="damageType">Тип урона</param>
    public override void UseAbility(Player player, Enemy enemy, int steps, ref int damage, ref int weaponDamage, DamageType damageType)
    {
        if (abilityOwner == AbilityOwner.Player)
        {
            // Проверяем уровень игрока и сравниваем ловкость
            if (requiredLevel <= currentLevel && player.agility > enemy.enemyData.agility)
            {
                Debug.Log("Stealth Attack: Player's agility is higher than Enemy's. Increasing damage by 1.");
                damage += 1;
            }
        }
        else
        {
            // Для врага: сравниваем ловкость
            if (player.agility < enemy.enemyData.agility)
            {
                Debug.Log("Stealth Attack: Enemy's agility is higher than Player's. Increasing damage by 1.");
                damage += 1;
            }
        }
    }

    #endregion
}
