using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public abstract class SpawnerBase<T> : MonoBehaviour
    where T : Object
{
    [SerializeField] private T _prefab;
    [SerializeField] private Transform _spawnPointsContainer;

    private ObjectPool<T> _pool;
    private List<Transform> _spawnPoints;

    protected abstract Transform GetSpawnPoint();

    protected void Awake()
    {
        _spawnPoints = new List<Transform>();

        foreach (Transform child in _spawnPointsContainer)
        {
            _spawnPoints.Add(child);
        }

        _pool = new ObjectPool<T>(
            createFunc: () => CreateObject(),
            actionOnGet: (obj) => GetObject(obj),
            actionOnRelease: (obj) => ReleaseObject(obj),
            actionOnDestroy: (obj) => DestroyObject(obj),
            collectionCheck: true,
            defaultCapacity: 10,
            maxSize: 20
            );
    }

    private void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    public void Release(T obj)
    {
        _pool.Release(obj);
    }

    private void DestroyObject(T obj)
    {
        var gameObject = obj.GameObject();

        Destroy(gameObject);
    }

    protected ReadOnlyCollection<Transform> GetSpawnPoints()
    {
        return _spawnPoints.AsReadOnly();
    }

    private void GetObject(T obj)
    {
        var gameObject = obj.GameObject();
        var spawnPoint = GetSpawnPoint();

        gameObject.transform.position = spawnPoint.position;
        gameObject.SetActive(true);
    }
    
    private void ReleaseObject(T obj)
    {
        var gameObject = obj.GameObject();

        gameObject.SetActive(false);
    }

    private T CreateObject()
    {
        return Instantiate(_prefab);
    }

    private IEnumerator SpawnObjects()
    {
        var wait = new WaitForSeconds(1);

        while (_pool.CountAll < _spawnPoints.Count)
        {
            _pool.Get();

            yield return wait;
        }
    }
}