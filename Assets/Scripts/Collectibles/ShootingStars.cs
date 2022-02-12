/// Title of class:
///     Shooting stars
/// Description:
///     
///
/// Author: Alex Nigl


using UnityEngine;

public class ShootingStars : MonoBehaviour
{
    private int LowSpawnCount { get; set; }

    /// <summary>
    /// 
    /// </summary>
    private int HighSpawnCount { get; set; }

    /// <summary>
    /// 
    /// </summary>
    private int SpawnCount { get; set; }

    /// <summary>
    /// 
    /// </summary>
    private bool GameRunning { get; set; }

    /// <summary>
    /// 
    /// </summary>
    private GameObject star;

    /// <summary>
    /// 
    /// </summary>
    private GameObject[] stars;

    /// <summary>
    /// s
    /// </summary>
    public GameObject PlanetPrefab;

    /// <summary>
    /// 
    /// </summary>
    private Vector2 objectPoolPosition;

    /// <summary>
    /// 
    /// </summary>
    private float spawnXPosition;

    /// <summary>
    /// 
    /// </summary>
    private float spawnYPosition;

    /// <summary>
    /// 
    /// </summary>
    private float spawnRate;

    /// <summary>
    /// 
    /// </summary>
    private float timeSinceLastSpawned;

    /// <summary>
    /// 
    /// </summary>
    private int CurrentStar;

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
    private void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (timeSinceLastSpawned >= spawnRate && GameRunning)
        {
            timeSinceLastSpawned = 0f;

            spawnYPosition = Random.Range(-4, 4);

            stars[CurrentStar].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            stars[CurrentStar].GetComponent<Star>().PlanetStates = PlanetStates.HasNotScored;

            CurrentStar++;
            if (CurrentStar >= SpawnCount)
            {
                CurrentStar = 0;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void Initialize()
    {
        star = Resources.Load("Star") as GameObject;
        LowSpawnCount = RandomHelper.ReturnRandom(1, 2);
        HighSpawnCount = RandomHelper.ReturnRandom(4, 5);
        SpawnCount = RandomHelper.ReturnRandom(LowSpawnCount, HighSpawnCount);
        stars = new GameObject[SpawnCount];

        CurrentStar = 0;
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
        stars = new GameObject[SpawnCount];
        for (int i = 0; i < SpawnCount; i++)
        {
            stars[i] = Instantiate(star, objectPoolPosition, Quaternion.identity);
        }
        GameRunning = true;
    }

    /// <summary>
    /// 
    /// </summary>
    public void Despawn()
    {
        GameRunning = false;
        foreach (GameObject g in stars)
        {
            Destroy(g);
        }
    }
}