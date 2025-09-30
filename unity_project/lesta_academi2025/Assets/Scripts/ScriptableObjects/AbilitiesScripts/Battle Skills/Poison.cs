using UnityEngine;

/// <summary>
/// ����������� "��". ������� �������������� ���� ������� �� ������� ���� ���.
/// </summary>
[CreateAssetMenu(fileName = "Poison", menuName = "Abilities/Battle Skills/Poison")]
public class Poison : Abilities
{
    #region �������� ������ �����������

    /// <summary>
    /// ��������� ������ ����������� "��".
    /// </summary>
    /// <param name="player">�����</param>
    /// <param name="enemy">����</param>
    /// <param name="steps">������� ��� ���</param>
    /// <param name="damage">���� (�� ������)</param>
    /// <param name="weaponDamage">���� ������ (�� ������)</param>
    /// <param name="damageType">��� �����</param>
    public override void UseAbility(Player player, Enemy enemy, int steps, ref int damage, ref int weaponDamage, DamageType damageType)
    {
        // ��� ������: ��������� ������� � ��������� ������
        if (abilityOwner == AbilityOwner.Player)
        {
            if (requiredLevel <= currentLevel && steps > 1)
            {
                damage += steps - 1;
                Debug.Log($"Poison: Damage increased by {steps - 1}.");
            }
        }
        // ��� �����: ������ ���
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
