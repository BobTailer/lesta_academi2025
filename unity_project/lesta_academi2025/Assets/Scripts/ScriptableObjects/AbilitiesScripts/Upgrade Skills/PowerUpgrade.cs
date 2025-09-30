using UnityEngine;

/// <summary>
/// Способность "Улучшение силы".
/// При достижении требуемого уровня увеличивает силу игрока на 1.
/// </summary>
[CreateAssetMenu(fileName = "PowerUpgrade", menuName = "Abilities/Upgrade Skills/PowerUpgrade")]
public class PowerUpgrade : Abilities
{
    #region Основная логика способности

    /// <summary>
    /// Применяет эффект способности "Улучшение силы".
    /// </summary>
    /// <param name="player">Игрок, на которого применяется способность</param>
    /// <param name="enemy">Враг (не используется)</param>
    /// <param name="steps">Текущий шаг боя (не используется)</param>
    /// <param name="damage">Урон (по ссылке, не используется)</param>
    /// <param name="weaponDamage">Урон оружия (по ссылке, не используется)</param>
    /// <param name="damageType">Тип урона (не используется)</param>
    public override void UseAbility(Player player, Enemy enemy, int steps, ref int damage, ref int weaponDamage, DamageType damageType)
    {
        // Если уровень игрока соответствует требуемому, увеличиваем силу
        if (requiredLevel == currentLevel)
        {
            player.UpgradeStats(1, 0, 0);
            Debug.Log("PowerUpgrade: Power increased by 1.");
        }
    }

    #endregion
}
