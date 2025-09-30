using UnityEngine;

/// <summary>
/// Способность "Импульс". На первом шаге боя увеличивает урон на урон оружия и удваивает урон оружия.
/// </summary>
[CreateAssetMenu(fileName = "Impulse", menuName = "Abilities/Battle Skills/Impulse")]
public class Impulse : Abilities
{
    #region Основная логика способности

    /// <summary>
    /// Применяет эффект способности "Импульс".
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
            if (requiredLevel <= currentLevel && steps == 1)
            {
                damage += weaponDamage;
                weaponDamage *= 2;
                Debug.Log("Impulse: Damage increased by weapon damage and weapon damage doubled.");
            }
        }
        // Для врага: только шаг
        else
        {
            if (steps == 1)
            {
                damage += weaponDamage;
                weaponDamage *= 2;
                Debug.Log("Impulse: Damage increased by weapon damage and weapon damage doubled.");
            }
        }
    }

    #endregion
}
