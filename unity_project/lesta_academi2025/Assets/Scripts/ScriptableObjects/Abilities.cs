using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ���� ������������: ����, ������, �������� �������������.
/// </summary>
public enum AbilityType
{
    Damage,
    Defend,
    StatBoost
}

/// <summary>
/// �������� ������������: ����� ��� ����.
/// </summary>
public enum AbilityOwner
{     
    Player,
    Enemy
}

/// <summary>
/// ����������� ������� ����� ��� ���� ������������.
/// </summary>
public abstract class Abilities : ScriptableObject
{
    #region �������� ��������� �����������

    /// <summary>��������� ������� ��� ��������� �����������.</summary>
    public int requiredLevel;

    /// <summary>������� ������� ��������� �����������.</summary>
    public int currentLevel;

    /// <summary>��� �����������.</summary>
    public AbilityType abilityType;

    /// <summary>�������� ����������� (����� ��� ����).</summary>
    public AbilityOwner abilityOwner;

    /// <summary>�������� �����������.</summary>
    public string abilityName;

    /// <summary>�������� �����������.</summary>
    public string abilityDescription;

    #endregion

    #region �������� ������ �����������

    /// <summary>
    /// ����������� ����� ���������� �����������.
    /// </summary>
    /// <param name="player">�����, �� �������� ����������� �����������</param>
    /// <param name="enemy">����, �� �������� ����������� �����������</param>
    /// <param name="steps">������� ��� ���</param>
    /// <param name="damage">���� (�� ������)</param>
    /// <param name="weaponDamage">���� ������ (�� ������)</param>
    /// <param name="damageType">��� �����</param>
    public abstract void UseAbility(Player player, Enemy enemy, int steps, ref int damage, ref int weaponDamage, DamageType damageType);

    #endregion
}
