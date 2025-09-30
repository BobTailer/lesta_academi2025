using UnityEngine;

/// <summary>
/// ������������ ����� ������.
/// </summary>
public enum EnemyType
{
    Goblin,
    Skeleton,
    Slime,
    Ghost,
    Golem,
    Dragon
}

/// <summary>
/// ScriptableObject ��� �������� ������ �����.
/// </summary>
[CreateAssetMenu(fileName = "Enemy", menuName = "Enemies")]
public class Enemies : ScriptableObject
{
    #region �������� ��������� �����

    /// <summary>��� �����.</summary>
    public EnemyType enemyType;

    /// <summary>���� �������� �����.</summary>
    public int hp;

    /// <summary>������� ����� �����.</summary>
    public int atk;

    /// <summary>���� �����.</summary>
    public int power;

    /// <summary>�������� �����.</summary>
    public int agility;

    /// <summary>������������ �����.</summary>
    public int endurance;

    /// <summary>������ �����.</summary>
    public Sprite icon;

    /// <summary>��� �����.</summary>
    public string enemyName;

    /// <summary>������� �� ������ ��� ������ (������).</summary>
    public Weapon reward;

    /// <summary>����������� �����.</summary>
    public Abilities ability;

    #endregion
}
