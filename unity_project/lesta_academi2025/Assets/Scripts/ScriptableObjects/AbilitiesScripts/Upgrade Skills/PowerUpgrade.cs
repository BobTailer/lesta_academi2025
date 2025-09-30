using UnityEngine;

/// <summary>
/// ����������� "��������� ����".
/// ��� ���������� ���������� ������ ����������� ���� ������ �� 1.
/// </summary>
[CreateAssetMenu(fileName = "PowerUpgrade", menuName = "Abilities/Upgrade Skills/PowerUpgrade")]
public class PowerUpgrade : Abilities
{
    #region �������� ������ �����������

    /// <summary>
    /// ��������� ������ ����������� "��������� ����".
    /// </summary>
    /// <param name="player">�����, �� �������� ����������� �����������</param>
    /// <param name="enemy">���� (�� ������������)</param>
    /// <param name="steps">������� ��� ��� (�� ������������)</param>
    /// <param name="damage">���� (�� ������, �� ������������)</param>
    /// <param name="weaponDamage">���� ������ (�� ������, �� ������������)</param>
    /// <param name="damageType">��� ����� (�� ������������)</param>
    public override void UseAbility(Player player, Enemy enemy, int steps, ref int damage, ref int weaponDamage, DamageType damageType)
    {
        // ���� ������� ������ ������������� ����������, ����������� ����
        if (requiredLevel == currentLevel)
        {
            player.UpgradeStats(1, 0, 0);
            Debug.Log("PowerUpgrade: Power increased by 1.");
        }
    }

    #endregion
}
