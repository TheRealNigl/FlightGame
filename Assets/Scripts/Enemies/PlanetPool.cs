/// Title of class:
///     PlanetPool
/// Description:
///     Controls enemy, planet, collection management and 
///         spawn/despawn
///
/// Author: Alex NiglAlex Nigl


using UnityEngine;

public class PlanetPool : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    public GameObject PlanetPrefab;

    /// <summary>
    /// 
    /// </summary>
    private bool GameRunning;

    /// <summary>
    /// 
    /// </summary>
    private int PlanetPoolSize;

    /// <summary>
    /// 
    /// </summary>
    private float spawnRate;

    /// <summary>
    /// 
    /// </summary>
    private GameObject[] Planets;

    /// <summary>
    /// 
    /// </summary>
    private int CurrentPlanet;

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
    private float timeSinceLastSpawned;
    
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
            
            Planets[CurrentPlanet].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            Planets[CurrentPlanet].GetComponent<Planet>().PlanetStates = PlanetStates.HasNotScored;

            CurrentPlanet++;
            if (CurrentPlanet >= PlanetPoolSize) {
                CurrentPlanet = 0;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void Initialize()
    {
        GameRunning = false;
        PlanetPoolSize = 5;
        spawnRate = 3f;
        CurrentPlanet = 0;
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
        Planets = new GameObject[PlanetPoolSize];
        for (int i = 0; i < PlanetPoolSize; i++)
        {
            Planets[i] = Instantiate(PlanetPrefab, objectPoolPosition, Quaternion.identity);
        }
        GameRunning = true;
    }

    /// <summary>
    /// 
    /// </summary>
    public void Despawn()
    {
        GameRunning = false;
        foreach(GameObject g in Planets)
        {
            Destroy(g);
        }
    }
}