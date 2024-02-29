using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomSpawner<T> : SpawnerBase<T>
    where T : Object, new()
{
    private int pointsCount;
    private List<Transform> _spawnPoints;

    private new void Awake()
    {
        base.Awake();

        _spawnPoints = GetSpawnPoints().ToList();
    }

    protected override Transform GetSpawnPoint()
    {
        if (pointsCount == _spawnPoints.Count)
        {
            pointsCount = 0;
        }

        var randomIndex = Random.Range(0, _spawnPoints.Count - pointsCount);
        var randomPoint = _spawnPoints[randomIndex];

        _spawnPoints.Add(randomPoint);
        _spawnPoints.RemoveAt(randomIndex);

        return randomPoint;
    }
}