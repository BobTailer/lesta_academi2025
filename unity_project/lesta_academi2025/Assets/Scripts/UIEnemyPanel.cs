using UnityEngine;
using UnityEngine.UI;

public class UIEnemyPanel : MonoBehaviour
{
    [SerializeField] private Enemies _enemy;

    [SerializeField] private Image _nextEnemyIcon;
    [SerializeField] private Text _nextEnemyName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _nextEnemyIcon.sprite = _enemy.icon;
        _nextEnemyName.text = _enemy.enemyName;
    }
}
