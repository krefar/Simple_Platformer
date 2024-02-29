using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomSpawner<T> : SpawnerBase<T>
    where T : Object, new()
{
    private int pointsCount;

    private new void Awake()
    {
        base.Awake();
    }

    protected override Transform GetSpawnPoint()
    {
        if (pointsCount == SpawnPoints.Count)
        {
            pointsCount = 0;
        }

        var randomIndex = Random.Range(0, SpawnPoints.Count - pointsCount);
        var randomPoint = SpawnPoints[randomIndex];

        SpawnPoints.Insert(SpawnPoints.Count, randomPoint);
        SpawnPoints.RemoveAt(randomIndex);

        return SpawnPoints.Last();
    }
}