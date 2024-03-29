﻿/// Title of class:
///
/// Description:
///     
///
/// Author: Alex Nigl


using UnityEngine;

public class StarTwinkle : PoolHandler
{
    protected override void Initialize()
    {
        base.Initialize();

        prefabInstance = Resources.Load("Star_Twinkle") as GameObject;
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
