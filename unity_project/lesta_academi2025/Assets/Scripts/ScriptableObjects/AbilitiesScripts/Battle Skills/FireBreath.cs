using UnityEngine;

/// <summary>
/// ����������� "�������� �������". ������ 3 ���� ����������� ���� �� 3.
/// </summary>
[CreateAssetMenu(fileName = "FireBreath", menuName = "Abilities/Battle Skills/FireBreath")]
public class FireBreath : Abilities
{
    #region �������� ������ �����������

    /// <summary>
    /// ��������� ������ ����������� "�������� �������".
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
            if (requiredLevel <= currentLevel && steps % 3 == 0)
            {
                damage += 3;
                Debug.Log("FireBreath: Damage increased by 3.");
            }
        }
        // ��� �����: ������ ����
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
