using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioResource _backgroundRestMusic;
    [SerializeField] private AudioResource _backgroundBattleMusic;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        GameManager.Instance.Battle += () =>
        {
            _audioSource.resource = _backgroundBattleMusic;
            _audioSource.volume = 0.01f;
            _audioSource.Play();
        };

        GameManager.Instance.Rest += () =>
        {
            _audioSource.resource = _backgroundRestMusic;
            _audioSource.volume = 0.05f;
            _audioSource.Play();
        };
    }

    void Update()
    {
        
    }
}
