using UnityEngine;

/// <summary>
/// Способность "Ярость".
/// Увеличивает урон на 2 при первых трёх шагах боя, затем уменьшает на 1.
/// </summary>
[CreateAssetMenu(fileName = "Rage", menuName = "Abilities/Battle Skills/Rage")]
public class Rage : Abilities
{
    #region Основная логика способности

    /// <summary>
    /// Применяет эффект способности "Ярость".
    /// </summary>
    /// <param name="player">Игрок, на которого применяется способность</param>
    /// <param name="enemy">Враг, на которого применяется способность</param>
    /// <param name="steps">Текущий шаг боя</param>
    /// <param name="damage">Урон (по ссылке)</param>
    /// <param name="weaponDamage">Урон оружия (по ссылке)</param>
    /// <param name="damageType">Тип урона</param>
    public override void UseAbility(Player player, Enemy enemy, int steps, ref int damage, ref int weaponDamage, DamageType damageType)
    {
        // Для игрока: проверяем уровень и применяем эффект
        if (abilityOwner == AbilityOwner.Player)
        {
            if (requiredLevel <= currentLevel)
            {
                ApplyRageEffect(steps, ref damage);
            }
        }
        // Для врага
        else
        {
            if (steps > 1)
            {
                ApplyRageEffect(steps, ref damage);
            }
        }
    }

    #endregion

    #region Вспомогательные методы

    /// <summary>
    /// Применяет модификатор урона в зависимости от шага боя.
    /// </summary>
    /// <param name="steps">Текущий шаг боя</param>
    /// <param name="damage">Урон (по ссылке)</param>
    private void ApplyRageEffect(int steps, ref int damage)
    {
        if (steps < 4)
        {
            damage += 2;
            Debug.Log("Rage: Damage increased by 2.");
        }
        else
        {
            damage -= 1;
            Debug.Log("Rage: Damage decreased by 1.");
        }
    }

    #endregion
}
