﻿/// Title of class:
///     PlanetPool
/// Description:
///     Controls enemy, planet, collection management and 
///         spawn/despawn
///
/// Author: Alex NiglAlex Nigl


using UnityEngine;

public class PlanetPool : PoolHandler
{
    protected override void Initialize()
    {
        base.Initialize();

        prefabInstance = Resources.Load("Planet") as GameObject;

        LowSpawnCount = RandomHelper.ReturnRandom(1, 2);
        HighSpawnCount = RandomHelper.ReturnRandom(4, 5);
        SpawnCount = RandomHelper.ReturnRandom(LowSpawnCount, HighSpawnCount);
    }

    /// <summary>
    /// 
    /// </summary>
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (timeSinceLastSpawned >= spawnRate && GameRunning)
        {
            timeSinceLastSpawned = 0f;

            spawnYPosition = Random.Range(-4, 4);

            prefabInstances[CurrentInstance].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            prefabInstances[CurrentInstance].GetComponent<Planet>().EnemyStates = EnemyStates.HasNotScored;

            CurrentInstance++;
            if (CurrentInstance >= SpawnCount)
            {
                CurrentInstance = 0;
            }
            else
            {
                CurrentInstance = 0;
            }
        }
    }
}