using UnityEngine;

/// <summary>
/// Способность "Яд". Наносит дополнительный урон начиная со второго шага боя.
/// </summary>
[CreateAssetMenu(fileName = "Poison", menuName = "Abilities/Battle Skills/Poison")]
public class Poison : Abilities
{
    #region Основная логика способности

    /// <summary>
    /// Применяет эффект способности "Яд".
    /// </summary>
    /// <param name="player">Игрок</param>
    /// <param name="enemy">Враг</param>
    /// <param name="steps">Текущий шаг боя</param>
    /// <param name="damage">Урон (по ссылке)</param>
    /// <param name="weaponDamage">Урон оружия (по ссылке)</param>
    /// <param name="damageType">Тип урона</param>
    public override void UseAbility(Player player, Enemy enemy, int steps, ref int damage, ref int weaponDamage, DamageType damageType)
    {
        // Для игрока: проверяем уровень и применяем эффект
        if (abilityOwner == AbilityOwner.Player)
        {
            if (requiredLevel <= currentLevel && steps > 1)
            {
                damage += steps - 1;
                Debug.Log($"Poison: Damage increased by {steps - 1}.");
            }
        }
        // Для врага: только шаг
        else
        {
            if (steps > 1)
            {
                damage += steps - 1;
                Debug.Log($"Poison: Damage increased by {steps - 1}.");
            }
        }
    }

    #endregion
}
