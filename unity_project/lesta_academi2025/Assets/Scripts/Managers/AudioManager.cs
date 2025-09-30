using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// �������� �����: ��������� �������� ������������ ������ ��� ������ � ���.
/// </summary>
public class AudioManager : MonoBehaviour
{
    #region ���� � ������

    [SerializeField] private AudioResource _backgroundRestMusic;
    [SerializeField] private AudioResource _backgroundBattleMusic;

    private AudioSource _audioSource;

    #endregion

    #region Unity Events

    /// <summary>
    /// ������������� ���������� AudioSource.
    /// </summary>
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// �������� �� ������� GameManager ��� ����� ������.
    /// </summary>
    private void Start()
    {
        // ����� ������ �� ������
        GameManager.Instance.Battle += () =>
        {
            _audioSource.resource = _backgroundBattleMusic;
            _audioSource.volume = 0.01f;
            _audioSource.Play();
        };

        // ����� ������ �� ���������
        GameManager.Instance.Rest += () =>
        {
            _audioSource.resource = _backgroundRestMusic;
            _audioSource.volume = 0.05f;
            _audioSource.Play();
        };
    }

    #endregion
}
