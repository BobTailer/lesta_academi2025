using UnityEngine;

/// <summary>
/// Способность "Улучшение ловкости".
/// При достижении требуемого уровня увеличивает ловкость игрока на 1.
/// </summary>
[CreateAssetMenu(fileName = "AgilityUpgrade", menuName = "Abilities/Upgrade Skills/AgilityUpgrade")]
public class AgilityUpgrade : Abilities
{
    #region Основная логика способности

    /// <summary>
    /// Применяет эффект способности "Улучшение ловкости".
    /// </summary>
    /// <param name="player">Игрок, на которого применяется способность</param>
    /// <param name="enemy">Враг (не используется)</param>
    /// <param name="steps">Текущий шаг боя (не используется)</param>
    /// <param name="damage">Урон (по ссылке, не используется)</param>
    /// <param name="weaponDamage">Урон оружия (по ссылке, не используется)</param>
    /// <param name="damageType">Тип урона (не используется)</param>
    public override void UseAbility(Player player, Enemy enemy, int steps, ref int damage, ref int weaponDamage, DamageType damageType)
    {
        // Если уровень игрока соответствует требуемому, увеличиваем ловкость
        if (requiredLevel == currentLevel)
        {
            player.UpgradeStats(0, 1, 0);
            Debug.Log("AgilityUpgrade: Agility increased by 1.");
        }
    }

    #endregion
}
