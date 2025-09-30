using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ������������ ����� ����������.
/// </summary>
public enum CharacterType
{
    Bandit,
    Warrior,
    Barbarian
}

/// <summary>
/// ScriptableObject ��� �������� ������ ���������.
/// </summary>
[CreateAssetMenu(fileName = "Character", menuName = "Characters")]
public class Characters : ScriptableObject
{
    #region �������� ��������� ���������

    /// <summary>��� ���������.</summary>
    public CharacterType character;

    /// <summary>������ ���������.</summary>
    public Weapon weapon;

    /// <summary>���������� HP, ����������� �� �������.</summary>
    public int HpPerLevel;

    /// <summary>������� ������� ���������.</summary>
    public int level;

    /// <summary>������ ������������ ���������.</summary>
    public Abilities[] abilities;

    /// <summary>��� ���������.</summary>
    public string characterName;

    /// <summary>������ ���������.</summary>
    public Sprite icon;

    #endregion

    #region ������

    /// <summary>
    /// �������� ������� ��������� � ���������� ��������.
    /// </summary>
    public void ResetLevel()
    {
        level = 0;
    }

    #endregion
}
