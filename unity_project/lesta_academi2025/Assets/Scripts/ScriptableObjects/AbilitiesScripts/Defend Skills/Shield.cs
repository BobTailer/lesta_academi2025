using UnityEngine;

/// <summary>
/// ����������� "���".
/// ��� ������: ���� ���� ������ ������ ���� ����� � ������� ���������� � ��������� ���� �� 3 (�� ����� 0).
/// </summary>
[CreateAssetMenu(fileName = "Shield", menuName = "Abilities/Defend Skills/Shield")]
public class Shield : Abilities
{
    #region �������� ������ �����������

    /// <summary>
    /// ��������� ������ ����������� "���".
    /// </summary>
    /// <param name="player">�����, �� �������� ����������� �����������</param>
    /// <param name="enemy">����, �� �������� ����������� �����������</param>
    /// <param name="steps">������� ��� ���</param>
    /// <param name="damage">���� (�� ������)</param>
    /// <param name="weaponDamage">���� ������ (�� ������)</param>
    /// <param name="damageType">��� �����</param>
    public override void UseAbility(Player player, Enemy enemy, int steps, ref int damage, ref int weaponDamage, DamageType damageType)
    {
        // ��� ������: ��������� ������� � ���������� ����
        if (abilityOwner == AbilityOwner.Player)
        {
            if (requiredLevel <= currentLevel)
            {
                if (player.power > enemy.enemyData.power)
                {
                    damage -= 3;
                    if (damage < 0) damage = 0;
                    Debug.Log("Shield: Damage reduced by 3.");
                }
            }
        }
        // ��� �����: ���������� ��������
        else
        {
            if (player.agility < enemy.enemyData.agility)
            {
                damage -= 3;
                if (damage < 0) damage = 0;
                Debug.Log("Shield: Damage reduced by 3.");
            }
        }
    }

    #endregion
}
