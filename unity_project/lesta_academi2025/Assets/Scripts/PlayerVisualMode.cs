using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerVisualMode : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _banditSprite;
    [SerializeField] private SpriteRenderer _barbarianSprite;
    [SerializeField] private SpriteRenderer _warriorSprite;

    [SerializeField] private Player _player;

    private void Start()
    {
        _player.OnLevelUp += OnLevelUp;
    }

    private void Update()
    {
        OnLevelUp();
    }

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
}
