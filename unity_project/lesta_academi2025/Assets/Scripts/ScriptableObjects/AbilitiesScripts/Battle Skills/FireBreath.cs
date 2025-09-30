using UnityEngine;

/// <summary>
/// Способность "Огненное дыхание". Каждые 3 шага увеличивает урон на 3.
/// </summary>
[CreateAssetMenu(fileName = "FireBreath", menuName = "Abilities/Battle Skills/FireBreath")]
public class FireBreath : Abilities
{
    #region Основная логика способности

    /// <summary>
    /// Применяет эффект способности "Огненное дыхание".
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
            if (requiredLevel <= currentLevel && steps % 3 == 0)
            {
                damage += 3;
                Debug.Log("FireBreath: Damage increased by 3.");
            }
        }
        // Для врага: только шаги
        else
        {
            if (steps % 3 == 0)
            {
                damage += 3;
                Debug.Log("FireBreath: Damage increased by 3.");
            }
        }
    }

    #endregion
}
