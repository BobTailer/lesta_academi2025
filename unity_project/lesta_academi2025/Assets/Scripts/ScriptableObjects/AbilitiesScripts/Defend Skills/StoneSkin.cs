using UnityEngine;

/// <summary>
/// ����������� "�������� ����".
/// ��� ������: ��� ����������� ������ ��������� ���� �� �������� ������������ ������.
/// ��� �����: ��������� ���� �� �������� ������������ �����.
/// </summary>
[CreateAssetMenu(fileName = "StoneSkin", menuName = "Abilities/Defend Skills/StoneSkin")] 
public class StoneSkin : Abilities
{
    #region �������� ������ �����������

    /// <summary>
    /// ��������� ������ ����������� "�������� ����".
    /// </summary>
    /// <param name="player">�����, �� �������� ����������� �����������</param>
    /// <param name="enemy">����, �� �������� ����������� �����������</param>
    /// <param name="steps">������� ��� ���</param>
    /// <param name="damage">���� (�� ������)</param>
    /// <param name="weaponDamage">���� ������ (�� ������)</param>
    /// <param name="damageType">��� �����</param>
    public override void UseAbility(Player player, Enemy enemy, int steps, ref int damage, ref int weaponDamage, DamageType damageType)
    {
        // ��� ������: ��������� ������� � ��������� ���� �� ������������ ������
        if (abilityOwner == AbilityOwner.Player)
        {
            if (requiredLevel <= currentLevel)
            {
                damage -= player.endurance;
                Debug.Log("Stone Skin: Damage reduced by endurance.");
            }
        }
        // ��� �����: ��������� ���� �� ������������ �����
        else
        {
            damage -= enemy.enemyData.endurance;
            Debug.Log("Stone Skin: Damage reduced by endurance.");
        }
    }

    #endregion
}
