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
            actionOnGet: (interactableItem) => OnGetIneractbableItem(interactableItem)
            );
    }

    private void Start()
    {
        for (int i = 0; i < _spawnPoints.Count; i++)
            _pool.Get();
    }

    protected virtual void OnGetIneractbableItem(T interactableItem)
    {
        var spawnPoint = _spawnPoints[_currentSpawnIndex];
        interactableItem.transform.position = spawnPoint.transform.position;
        _currentSpawnIndex = _currentSpawnIndex++ % _spawnPoints.Count;
    }
}
