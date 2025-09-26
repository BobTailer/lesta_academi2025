using UnityEngine;

public class Player : MonoBehaviour
{
    private int _power;
    private int _agility;
    private int _endurance;

    public int power => _power;
    public int agility => _agility;
    public int endurance => _endurance;

    private Characters[] _squad;
    private Weapon _weapon;

    public Characters[] squad => _squad;
    public Weapon weapon => _weapon;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _power = Random.Range(1, 4);
        _agility = Random.Range(1, 4);
        _endurance = Random.Range(1, 4);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
