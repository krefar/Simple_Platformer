using Assets.Scripts.Services.Storage;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
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
    private ObjectPool<T> _pool;

    [SerializeField] private T _prefab;
    [SerializeField] private Transform _spawnPointsContainer;
    
    protected List<Transform> _spawnPoints;

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
            actionOnGet: (obj) => ActionOnGet(obj),
            actionOnRelease: (obj) => ActionOnRelease(obj),
            actionOnDestroy: (obj) => ActionOnDestroy(obj),
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

    private void ActionOnDestroy(T obj)
    {
        var gameObject = obj.GameObject();

        Destroy(gameObject);
    }

    private void ActionOnGet(T obj)
    {
        var gameObject = obj.GameObject();
        var spawnPoint = GetSpawnPoint();

        gameObject.transform.position = spawnPoint.position;
        gameObject.SetActive(true);
    }
    
    private void ActionOnRelease(T obj)
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

        while (_pool.CountActive < _spawnPoints.Count)
        {
            _pool.Get();

            yield return wait;
        }
    }
}