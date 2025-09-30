using UnityEngine;

/// <summary>
/// ����������� "�������". �� ������ ���� ��� ����������� ���� �� ���� ������ � ��������� ���� ������.
/// </summary>
[CreateAssetMenu(fileName = "Impulse", menuName = "Abilities/Battle Skills/Impulse")]
public class Impulse : Abilities
{
    #region �������� ������ �����������

    /// <summary>
    /// ��������� ������ ����������� "�������".
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
            if (requiredLevel <= currentLevel && steps == 1)
            {
                damage += weaponDamage;
                weaponDamage *= 2;
                Debug.Log("Impulse: Damage increased by weapon damage and weapon damage doubled.");
            }
        }
        // ��� �����: ������ ���
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
