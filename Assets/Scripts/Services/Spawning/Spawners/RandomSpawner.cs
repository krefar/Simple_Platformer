using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner<T> : SpawnerBase<T>
    where T : Object, new()
{
    private List<int> _filledSpawnPointIndexes;

    private new void Awake()
    {
        base.Awake();

        _filledSpawnPointIndexes = new List<int>();
    }

    protected override Transform GetSpawnPoint()
    {
        if (_filledSpawnPointIndexes.Count == _spawnPoints.Count)
        {
            _filledSpawnPointIndexes.Clear();
        }

        var randomIndex = Random.Range(0, _spawnPoints.Count);

        while (_filledSpawnPointIndexes.Contains(randomIndex))
        {
            randomIndex = Random.Range(0, _spawnPoints.Count);
        }

        _filledSpawnPointIndexes.Add(randomIndex);

        return this._spawnPoints[randomIndex];
    }
}