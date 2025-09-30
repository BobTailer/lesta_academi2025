using UnityEngine;

/// <summary>
/// Способность "Иммунитет к рубящему урону".
/// Для игрока: при достаточном уровне полностью нейтрализует рубящий урон.
/// Для врага: эффект всегда активен при рубящем уроне.
/// </summary>
[CreateAssetMenu(fileName = "ImmuneCopping", menuName = "Abilities/Defend Skills/ImmuneCopping")]
public class ImmuneCopping : Abilities
{
    #region Основная логика способности

    /// <summary>
    /// Применяет эффект способности "Иммунитет к рубящему урону".
    /// </summary>
    /// <param name="player">Игрок, на которого применяется способность</param>
    /// <param name="enemy">Враг, на которого применяется способность</param>
    /// <param name="steps">Текущий шаг боя</param>
    /// <param name="damage">Урон (по ссылке)</param>
    /// <param name="weaponDamage">Урон оружия (по ссылке)</param>
    /// <param name="damageType">Тип урона</param>
    public override void UseAbility(Player player, Enemy enemy, int steps, ref int damage, ref int weaponDamage, DamageType damageType)
    {
        // Для игрока: проверяем уровень и тип урона
        if (abilityOwner == AbilityOwner.Player)
        {
            if (requiredLevel <= currentLevel)
            {
                if (damageType == DamageType.Chopping)
                {
                    // Полностью нейтрализуем рубящий урон
                    damage -= weaponDamage;
                    weaponDamage = 0;
                    Debug.Log("ImmuneCopping: Chopping damage nullified.");
                }
            }
        }
        // Для врага: только тип урона
        else
        {
            if (damageType == DamageType.Chopping)
            {
                // Полностью нейтрализуем рубящий урон
                damage -= weaponDamage;
                weaponDamage = 0;
                Debug.Log("ImmuneCopping: Chopping damage nullified.");
            }
        }
    }

    #endregion
}
