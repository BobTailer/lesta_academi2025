using UnityEngine;

public enum EnemyType
{
    Goblin,
    Skeleton,
    Slime,
    Ghost,
    Golem,
    Dragon
}

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemies")]
public class Enemies : ScriptableObject
{
    public EnemyType enemyType;

    public int hp;
    public int atk;
    public int power;
    public int agility;
    public int endurance;

    public Sprite icon;
    public string enemyName;

    public Weapon reward;

    public Abilities ability;
}
