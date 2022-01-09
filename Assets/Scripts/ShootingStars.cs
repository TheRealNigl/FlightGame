using System.Collections;
using UnityEngine;

public class ShootingStars : MonoBehaviour
{
    private GameObject star;
    private GameObject[] stars;
    private int LowSpawnCount { get; set; }
    private int HighSpawnCount { get; set; }
    private int SpawnCount { get; set; }

    private bool GameRunning { get; set; }

    public GameObject PlanetPrefab;

    private Vector2 objectPoolPosition;
    private float spawnXPosition;
    private float spawnYPosition;
    private float spawnRate;
    private float timeSinceLastSpawned;
    private int CurrentStar;

    private void Start() {
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

    void Update()
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

    public void SpawnObjects()
    {
        stars = new GameObject[SpawnCount];
        for (int i = 0; i < SpawnCount; i++)
        {
            stars[i] = Instantiate(star, objectPoolPosition, Quaternion.identity);
        }
        GameRunning = true;
    }

    public void Despawn()
    {
        GameRunning = false;
        foreach (GameObject g in stars)
        {
            Destroy(g);
        }
    }
}