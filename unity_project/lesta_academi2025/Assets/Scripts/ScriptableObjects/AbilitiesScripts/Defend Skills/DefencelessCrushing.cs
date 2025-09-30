using UnityEngine;

/// <summary>
/// Способность "Беззащитное сокрушение".
/// При нанесении дробящего урона увеличивает урон на значение урона оружия и удваивает урон оружия.
/// Для игрока: требуется соответствующий уровень.
/// Для врага: эффект всегда активен при дробящем уроне.
/// </summary>
[CreateAssetMenu(fileName = "DefencelessCrushing", menuName = "Abilities/Defend Skills/DefencelessCrushing")]
public class DefencelessCrushing : Abilities
{
    #region Основная логика способности

    /// <summary>
    /// Применяет эффект способности "Беззащитное сокрушение".
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
            // Проверяем уровень игрока и тип урона
            if (requiredLevel <= currentLevel && damageType == DamageType.Crushing)
            {
                ApplyCrushingEffect(ref damage, ref weaponDamage);
            }
        }
        else
        {
            // Для врага: только тип урона
            if (damageType == DamageType.Crushing)
            {
                ApplyCrushingEffect(ref damage, ref weaponDamage);
            }
        }
    }

    #endregion

    #region Вспомогательные методы

    /// <summary>
    /// Применяет эффект увеличения урона для дробящего типа.
    /// </summary>
    /// <param name="damage">Урон (по ссылке)</param>
    /// <param name="weaponDamage">Урон оружия (по ссылке)</param>
    private void ApplyCrushingEffect(ref int damage, ref int weaponDamage)
    {
        damage += weaponDamage;
        weaponDamage *= 2;
        Debug.Log("DefencelessCrushing: Crushing damage doubled.");
    }

    #endregion
}
