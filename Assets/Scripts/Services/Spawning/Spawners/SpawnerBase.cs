using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

/// <summary>
/// Базовый класс для описания поднимающего
/// </summary>
/// <typeparam name="T">Тип объекта для спавнера</typeparam>
public abstract class SpawnerBase<T> : MonoBehaviour
    where T : Object, new()
{
    [SerializeField] private T _prefab;
    [SerializeField] private Transform _spawnPointsContainer;

    private ObjectPool<T> _pool;
        
    protected List<Transform> SpawnPoints;

    protected abstract Transform GetSpawnPoint();

    protected void Awake()
    {
        SpawnPoints = new List<Transform>();

        foreach (Transform child in _spawnPointsContainer)
        {
            SpawnPoints.Add(child);
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

        while (_pool.CountActive < SpawnPoints.Count)
        {
            _pool.Get();

            yield return wait;
        }
    }
}