using UnityEngine;
using UnityEngine.Pool;

public class SpawnPoint<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;

    private ObjectPool<T> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<T>
            (createFunc: () => Instantiate(_prefab),
            actionOnGet: (t) => OnGet(t),
            actionOnRelease: (t) => t.gameObject.SetActive(false)
            );
    }

    private void Start()
    {
        _pool.Get();
    }

    private void OnGet(T t)
    {
        t.transform.position = transform.position;
    }
}
