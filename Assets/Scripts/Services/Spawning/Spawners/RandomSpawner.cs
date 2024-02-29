using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomSpawner<T> : SpawnerBase<T>
    where T : Object, new()
{
    private int pointsCount;
    private List<Transform> _baseSpawnPoints;

    private new void Awake()
    {
        base.Awake();

        _baseSpawnPoints = GetSpawnPoints().ToList();
    }

    protected override Transform GetSpawnPoint()
    {
        if (pointsCount == _baseSpawnPoints.Count)
        {
            pointsCount = 0;
        }

        var randomIndex = Random.Range(0, _baseSpawnPoints.Count - pointsCount);
        var randomPoint = _baseSpawnPoints[randomIndex];

        _baseSpawnPoints.Add(randomPoint);
        _baseSpawnPoints.RemoveAt(randomIndex);

        return randomPoint;
    }
}