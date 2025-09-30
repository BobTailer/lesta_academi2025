using UnityEngine;

/// <summary>
/// Способность "Улучшение выносливости".
/// При достижении требуемого уровня увеличивает выносливость игрока на 1.
/// </summary>
[CreateAssetMenu(fileName = "EnduranceUpgrade", menuName = "Abilities/Upgrade Skills/EnduranceUpgrade")]
public class EnduranceUpgrade : Abilities
{
    #region Основная логика способности

    /// <summary>
    /// Применяет эффект способности "Улучшение выносливости".
    /// </summary>
    /// <param name="player">Игрок, на которого применяется способность</param>
    /// <param name="enemy">Враг (не используется)</param>
    /// <param name="steps">Текущий шаг боя (не используется)</param>
    /// <param name="damage">Урон (по ссылке, не используется)</param>
    /// <param name="weaponDamage">Урон оружия (по ссылке, не используется)</param>
    /// <param name="damageType">Тип урона (не используется)</param>
    public override void UseAbility(Player player, Enemy enemy, int steps, ref int damage, ref int weaponDamage, DamageType damageType)
    {
        // Если уровень игрока соответствует требуемому, увеличиваем выносливость
        if (requiredLevel == currentLevel)
        {
            player.UpgradeStats(0, 0, 1);
            Debug.Log("EnduranceUpgrade: Endurance increased by 1.");
        }
    }

    #endregion
}
