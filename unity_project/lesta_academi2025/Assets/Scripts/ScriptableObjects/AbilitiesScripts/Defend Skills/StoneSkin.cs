using UnityEngine;

/// <summary>
/// Способность "Каменная кожа".
/// Для игрока: при достаточном уровне уменьшает урон на значение выносливости игрока.
/// Для врага: уменьшает урон на значение выносливости врага.
/// </summary>
[CreateAssetMenu(fileName = "StoneSkin", menuName = "Abilities/Defend Skills/StoneSkin")] 
public class StoneSkin : Abilities
{
    #region Основная логика способности

    /// <summary>
    /// Применяет эффект способности "Каменная кожа".
    /// </summary>
    /// <param name="player">Игрок, на которого применяется способность</param>
    /// <param name="enemy">Враг, на которого применяется способность</param>
    /// <param name="steps">Текущий шаг боя</param>
    /// <param name="damage">Урон (по ссылке)</param>
    /// <param name="weaponDamage">Урон оружия (по ссылке)</param>
    /// <param name="damageType">Тип урона</param>
    public override void UseAbility(Player player, Enemy enemy, int steps, ref int damage, ref int weaponDamage, DamageType damageType)
    {
        // Для игрока: проверяем уровень и уменьшаем урон на выносливость игрока
        if (abilityOwner == AbilityOwner.Player)
        {
            if (requiredLevel <= currentLevel)
            {
                damage -= player.endurance;
                Debug.Log("Stone Skin: Damage reduced by endurance.");
            }
        }
        // Для врага: уменьшаем урон на выносливость врага
        else
        {
            damage -= enemy.enemyData.endurance;
            Debug.Log("Stone Skin: Damage reduced by endurance.");
        }
    }

    #endregion
}
