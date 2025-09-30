using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    protected int _currentHP;
    protected int _maxHP;

    public int currentHP => _currentHP;
    public int maxHP => _maxHP;
}
