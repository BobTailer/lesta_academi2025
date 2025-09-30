using UnityEngine;

/// <summary>
/// ����������� "��������� ������������".
/// ��� ���������� ���������� ������ ����������� ������������ ������ �� 1.
/// </summary>
[CreateAssetMenu(fileName = "EnduranceUpgrade", menuName = "Abilities/Upgrade Skills/EnduranceUpgrade")]
public class EnduranceUpgrade : Abilities
{
    #region �������� ������ �����������

    /// <summary>
    /// ��������� ������ ����������� "��������� ������������".
    /// </summary>
    /// <param name="player">�����, �� �������� ����������� �����������</param>
    /// <param name="enemy">���� (�� ������������)</param>
    /// <param name="steps">������� ��� ��� (�� ������������)</param>
    /// <param name="damage">���� (�� ������, �� ������������)</param>
    /// <param name="weaponDamage">���� ������ (�� ������, �� ������������)</param>
    /// <param name="damageType">��� ����� (�� ������������)</param>
    public override void UseAbility(Player player, Enemy enemy, int steps, ref int damage, ref int weaponDamage, DamageType damageType)
    {
        // ���� ������� ������ ������������� ����������, ����������� ������������
        if (requiredLevel == currentLevel)
        {
            player.UpgradeStats(0, 0, 1);
            Debug.Log("EnduranceUpgrade: Endurance increased by 1.");
        }
    }

    #endregion
}
