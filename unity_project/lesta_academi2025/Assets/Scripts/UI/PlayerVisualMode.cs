using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

/// <summary>
/// ��������� ���������� ������������ ���������� ������ � ����������� �� �� ������.
/// </summary>
public class PlayerVisualMode : MonoBehaviour
{
    #region ������ �� ����������

    [SerializeField] private SpriteRenderer _banditSprite;
    [SerializeField] private SpriteRenderer _barbarianSprite;
    [SerializeField] private SpriteRenderer _warriorSprite;
    [SerializeField] private Player _player;

    #endregion

    #region Unity Events

    /// <summary>
    /// �������� �� ������� ��������� ������ ������.
    /// </summary>
    private void Start()
    {
        _player.OnLevelUp += OnLevelUp;
    }

    /// <summary>
    /// ��������� � ��������� ���������� ����� ������ ����.
    /// </summary>
    private void Update()
    {
        OnLevelUp();
    }

    #endregion

    #region �������� ������

    /// <summary>
    /// ��������� ������� ���������� � ����������� �� �� ������.
    /// </summary>
    private void OnLevelUp()
    {
        foreach (var character in _player.squad)
        {
            bool showSprite = character.level > 0;
            switch (character.character)
            {
                case CharacterType.Bandit:
                    _banditSprite.sprite = showSprite ? character.icon : null;
                    break;
                case CharacterType.Barbarian:
                    _barbarianSprite.sprite = showSprite ? character.icon : null;
                    break;
                case CharacterType.Warrior:
                    _warriorSprite.sprite = showSprite ? character.icon : null;
                    break;
                default:
                    break;
            }
        }
    }

    #endregion
}
