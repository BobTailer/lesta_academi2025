using UnityEngine;

/// <summary>
/// ����������� "������".
/// ����������� ���� �� 2 ��� ������ ��� ����� ���, ����� ��������� �� 1.
/// </summary>
[CreateAssetMenu(fileName = "Rage", menuName = "Abilities/Battle Skills/Rage")]
public class Rage : Abilities
{
    #region �������� ������ �����������

    /// <summary>
    /// ��������� ������ ����������� "������".
    /// </summary>
    /// <param name="player">�����, �� �������� ����������� �����������</param>
    /// <param name="enemy">����, �� �������� ����������� �����������</param>
    /// <param name="steps">������� ��� ���</param>
    /// <param name="damage">���� (�� ������)</param>
    /// <param name="weaponDamage">���� ������ (�� ������)</param>
    /// <param name="damageType">��� �����</param>
    public override void UseAbility(Player player, Enemy enemy, int steps, ref int damage, ref int weaponDamage, DamageType damageType)
    {
        // ��� ������: ��������� ������� � ��������� ������
        if (abilityOwner == AbilityOwner.Player)
        {
            if (requiredLevel <= currentLevel)
            {
                ApplyRageEffect(steps, ref damage);
            }
        }
        // ��� �����
        else
        {
            if (steps > 1)
            {
                ApplyRageEffect(steps, ref damage);
            }
        }
    }

    #endregion

    #region ��������������� ������

    /// <summary>
    /// ��������� ����������� ����� � ����������� �� ���� ���.
    /// </summary>
    /// <param name="steps">������� ��� ���</param>
    /// <param name="damage">���� (�� ������)</param>
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
