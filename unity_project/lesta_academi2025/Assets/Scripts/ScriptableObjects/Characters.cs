using UnityEngine;

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

    public void ResetLevel()
    {
           level = 0;
    }
}
