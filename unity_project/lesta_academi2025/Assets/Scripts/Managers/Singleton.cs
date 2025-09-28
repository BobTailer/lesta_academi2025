using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    [Header("Singleton")]
    [SerializeField] private bool _dontDestroyOnLoad;

    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning($"Another instance of {typeof(T)} already exists. Destroying this instance.");
            Destroy(this);
            return;
        }

        Instance = this as T;

        if (_dontDestroyOnLoad)
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}


