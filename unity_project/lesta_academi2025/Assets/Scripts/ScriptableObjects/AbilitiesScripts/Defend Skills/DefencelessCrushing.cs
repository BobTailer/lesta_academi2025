using UnityEngine;

/// <summary>
/// ����������� "����������� ����������".
/// ��� ��������� ��������� ����� ����������� ���� �� �������� ����� ������ � ��������� ���� ������.
/// ��� ������: ��������� ��������������� �������.
/// ��� �����: ������ ������ ������� ��� �������� �����.
/// </summary>
[CreateAssetMenu(fileName = "DefencelessCrushing", menuName = "Abilities/Defend Skills/DefencelessCrushing")]
public class DefencelessCrushing : Abilities
{
    #region �������� ������ �����������

    /// <summary>
    /// ��������� ������ ����������� "����������� ����������".
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
            // ��������� ������� ������ � ��� �����
            if (requiredLevel <= currentLevel && damageType == DamageType.Crushing)
            {
                ApplyCrushingEffect(ref damage, ref weaponDamage);
            }
        }
        else
        {
            // ��� �����: ������ ��� �����
            if (damageType == DamageType.Crushing)
            {
                ApplyCrushingEffect(ref damage, ref weaponDamage);
            }
        }
    }

    #endregion

    #region ��������������� ������

    /// <summary>
    /// ��������� ������ ���������� ����� ��� ��������� ����.
    /// </summary>
    /// <param name="damage">���� (�� ������)</param>
    /// <param name="weaponDamage">���� ������ (�� ������)</param>
    private void ApplyCrushingEffect(ref int damage, ref int weaponDamage)
    {
        damage += weaponDamage;
        weaponDamage *= 2;
        Debug.Log("DefencelessCrushing: Crushing damage doubled.");
    }

    #endregion
}
