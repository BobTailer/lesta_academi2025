using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum CharacterType
{
    Bandit,
    Warrior,
    Barbarian
}

[CreateAssetMenu(fileName = "Character", menuName = "Characters")]
public class Characters : ScriptableObject
{
    public CharacterType character;
    public int HpPerLevel;
    public int level;

    public Abilities[] abilities;

    public string characterName;
    public Sprite icon;

    public void ResetLevel()
    {
           level = 0;
    }
}
