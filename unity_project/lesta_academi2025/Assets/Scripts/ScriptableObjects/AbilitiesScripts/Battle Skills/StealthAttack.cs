using UnityEngine;

/// <summary>
/// ����������� "����� �� ����".
/// ��� ������: ���� �������� ������ ���� �������� ����� � ����������� ���� �� 1.
/// ��� �����: ���� �������� ����� ���� �������� ������ � ����������� ���� �� 1.
/// </summary>
[CreateAssetMenu(fileName = "StealthAttack", menuName = "Abilities/Battle Skills/StealthAttack")]
public class StealthAttack : Abilities
{
    #region �������� ������ �����������

    /// <summary>
    /// ��������� ������ ����������� "����� �� ����".
    /// </summary>
    /// <param name="player">�����, �� �������� ����������� �����������</param>
    /// <param name="enemy">����, �� �������� ����������� �����������</param>
    /// <param name="steps">������� ��� ���</param>
    /// <param name="damage">���� (�� ������)</param>
    /// <param name="weaponDamage">���� ������ (�� ������)</param>
    /// <param name="damageType">��� �����</param>
    public override void UseAbility(Player player, Enemy enemy, int steps, ref int damage, ref int weaponDamage, DamageType damageType)
    {
        if (abilityOwner == AbilityOwner.Player)
        {
            // ��������� ������� ������ � ���������� ��������
            if (requiredLevel <= currentLevel && player.agility > enemy.enemyData.agility)
            {
                Debug.Log("Stealth Attack: Player's agility is higher than Enemy's. Increasing damage by 1.");
                damage += 1;
            }
        }
        else
        {
            // ��� �����: ���������� ��������
            if (player.agility < enemy.enemyData.agility)
            {
                Debug.Log("Stealth Attack: Enemy's agility is higher than Player's. Increasing damage by 1.");
                damage += 1;
            }
        }
    }

    #endregion
}
