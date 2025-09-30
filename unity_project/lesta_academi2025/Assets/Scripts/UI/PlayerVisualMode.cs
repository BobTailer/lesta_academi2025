using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

/// <summary>
/// Управляет визуальным отображением персонажей игрока в зависимости от их уровня.
/// </summary>
public class PlayerVisualMode : MonoBehaviour
{
    #region Ссылки на компоненты

    [SerializeField] private SpriteRenderer _banditSprite;
    [SerializeField] private SpriteRenderer _barbarianSprite;
    [SerializeField] private SpriteRenderer _warriorSprite;
    [SerializeField] private Player _player;

    #endregion

    #region Unity Events

    /// <summary>
    /// Подписка на событие повышения уровня игрока.
    /// </summary>
    private void Start()
    {
        _player.OnLevelUp += OnLevelUp;
    }

    /// <summary>
    /// Проверяет и обновляет визуальный режим каждый кадр.
    /// </summary>
    private void Update()
    {
        OnLevelUp();
    }

    #endregion

    #region Основная логика

    /// <summary>
    /// Обновляет спрайты персонажей в зависимости от их уровня.
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
