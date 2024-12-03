using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner<T, K> : MonoBehaviour where T : MonoBehaviour where K : MonoBehaviour
{
    [SerializeField] private T _prefab;
    [SerializeField] private List<K> _spawnPoints;

    private int _currentSpawnIndex = 0;

    protected ObjectPool<T> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<T>
            (createFunc: () => Instantiate(_prefab),
            actionOnGet: (t) => OnGet(t),
            actionOnRelease: (t) => OnRelease(t)
            );
    }

    private void Start()
    {
        for (int i = 0; i < _spawnPoints.Count; i++)
        {
            _pool.Get();
        }
    }

    protected virtual void OnGet(T t)
    {
        var spawnPoint = _spawnPoints[_currentSpawnIndex];
        t.transform.position = spawnPoint.transform.position;
        _currentSpawnIndex = (_currentSpawnIndex + 1) % _spawnPoints.Count;
    }

    protected virtual void OnRelease(T t)
    {
        t.gameObject.SetActive(false);
    }
}
