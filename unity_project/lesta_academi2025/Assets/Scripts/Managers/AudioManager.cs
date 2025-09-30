using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// Менеджер аудио: управляет фоновыми музыкальными темами для отдыха и боя.
/// </summary>
public class AudioManager : MonoBehaviour
{
    #region Поля и ссылки

    [SerializeField] private AudioResource _backgroundRestMusic;
    [SerializeField] private AudioResource _backgroundBattleMusic;

    private AudioSource _audioSource;

    #endregion

    #region Unity Events

    /// <summary>
    /// Инициализация компонента AudioSource.
    /// </summary>
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Подписка на события GameManager для смены музыки.
    /// </summary>
    private void Start()
    {
        // Смена музыки на боевую
        GameManager.Instance.Battle += () =>
        {
            _audioSource.resource = _backgroundBattleMusic;
            _audioSource.volume = 0.01f;
            _audioSource.Play();
        };

        // Смена музыки на спокойную
        GameManager.Instance.Rest += () =>
        {
            _audioSource.resource = _backgroundRestMusic;
            _audioSource.volume = 0.05f;
            _audioSource.Play();
        };
    }

    #endregion
}
