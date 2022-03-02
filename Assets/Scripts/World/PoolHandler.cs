/// Title of class:
///     Pool Handler
/// Description:
///     Container for object pooling
///
/// Author: Alex Nigl
/// 

using System.Collections.Generic;
using UnityEngine;

public class PoolHandler : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    protected GameObject prefabInstance;

    /// <summary>
    /// 
    /// </summary>
    protected List<GameObject> prefabInstances;

    /// <summary>
    /// 
    /// </summary>
    protected int LowSpawnCount { get; set; }

    /// <summary>
    /// 
    /// </summary>
    protected int HighSpawnCount { get; set; }

    /// <summary>
    /// 
    /// </summary>
    protected int SpawnCount { get; set; }

    /// <summary>
    /// 
    /// </summary>
    protected bool GameRunning { get; set; }

    /// <summary>
    /// 
    /// </summary>
    private Vector2 objectPoolPosition;

    /// <summary>
    /// 
    /// </summary>
    protected float spawnXPosition;

    /// <summary>
    /// 
    /// </summary>
    protected float spawnYPosition;

    /// <summary>
    /// 
    /// </summary>
    protected float spawnRate;

    /// <summary>
    /// 
    /// </summary>
    protected float timeSinceLastSpawned;

    /// <summary>
    /// 
    /// </summary>
    protected int CurrentInstance;

    /// <summary>
    /// 
    /// </summary>
    public GameObject PrefabReference;

    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {
        Initialize();
    }

    /// <summary>
    /// 
    /// </summary>
    protected virtual void Initialize()
    {
        prefabInstances = new List<GameObject>(SpawnCount);

        CurrentInstance = 0;
        GameRunning = false;
        spawnRate = 3f;
        objectPoolPosition = new Vector2(transform.position.x, transform.position.y);
        spawnXPosition = 15f;
        spawnYPosition = Random.Range(-5, 5);
        timeSinceLastSpawned = 0f;
    }

    /// <summary>
    /// 
    /// </summary>
    public void SpawnObjects()
    {
        for (int i = 0; i < SpawnCount; i++)
        {
            prefabInstances.Add(Instantiate(prefabInstance, objectPoolPosition, Quaternion.identity));
        }
        GameRunning = true;
    }

    /// <summary>
    /// 
    /// </summary>
    public void Despawn()
    {
        GameRunning = false;
        foreach (GameObject g in prefabInstances)
        {
            Destroy(g);
        }
    }

    public void RemoveEnemy(Spawnable spawnable)
    {
        prefabInstances.Remove(spawnable.gameObject);
    }
}
