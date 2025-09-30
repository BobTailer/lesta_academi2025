using UnityEngine;

/// <summary>
/// ����������� "��������� � �������� �����".
/// ��� ������: ��� ����������� ������ ��������� ������������ ������� ����.
/// ��� �����: ������ ������ ������� ��� ������� �����.
/// </summary>
[CreateAssetMenu(fileName = "ImmuneCopping", menuName = "Abilities/Defend Skills/ImmuneCopping")]
public class ImmuneCopping : Abilities
{
    #region �������� ������ �����������

    /// <summary>
    /// ��������� ������ ����������� "��������� � �������� �����".
    /// </summary>
    /// <param name="player">�����, �� �������� ����������� �����������</param>
    /// <param name="enemy">����, �� �������� ����������� �����������</param>
    /// <param name="steps">������� ��� ���</param>
    /// <param name="damage">���� (�� ������)</param>
    /// <param name="weaponDamage">���� ������ (�� ������)</param>
    /// <param name="damageType">��� �����</param>
    public override void UseAbility(Player player, Enemy enemy, int steps, ref int damage, ref int weaponDamage, DamageType damageType)
    {
        // ��� ������: ��������� ������� � ��� �����
        if (abilityOwner == AbilityOwner.Player)
        {
            if (requiredLevel <= currentLevel)
            {
                if (damageType == DamageType.Chopping)
                {
                    // ��������� ������������ ������� ����
                    damage -= weaponDamage;
                    weaponDamage = 0;
                    Debug.Log("ImmuneCopping: Chopping damage nullified.");
                }
            }
        }
        // ��� �����: ������ ��� �����
        else
        {
            if (damageType == DamageType.Chopping)
            {
                // ��������� ������������ ������� ����
                damage -= weaponDamage;
                weaponDamage = 0;
                Debug.Log("ImmuneCopping: Chopping damage nullified.");
            }
        }
    }

    #endregion
}
