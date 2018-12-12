using UnityEngine;

public class PlanetPool : MonoBehaviour
{
    public GameObject PlanetPrefab;

    private bool GameRunning;
    private int PlanetPoolSize;
    private float spawnRate;
    private GameObject[] Planets;
    private int CurrentPlanet;
    private Vector2 objectPoolPosition;
    private float spawnXPosition;
    private float spawnYPosition;

    private float timeSinceLastSpawned;
    
    void Start() {
        GameRunning = false;
        PlanetPoolSize = 5;
        spawnRate = 3f;
        CurrentPlanet = 0;
        objectPoolPosition = new Vector2(transform.position.x, transform.position.y);
        spawnXPosition = 15f;
        spawnYPosition = Random.Range(-5, 5);
        timeSinceLastSpawned = 0f;
    }
    
    void Update() {
        timeSinceLastSpawned += Time.deltaTime;

        if (timeSinceLastSpawned >= spawnRate && GameRunning)  {
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

    public void SpawnObjects() {
        Planets = new GameObject[PlanetPoolSize];
        for (int i = 0; i < PlanetPoolSize; i++) {
            Planets[i] = Instantiate(PlanetPrefab, objectPoolPosition, Quaternion.identity);
        }
        GameRunning = true;
    }

    public void Despawn(){
        GameRunning = false;
        foreach(GameObject g in Planets){
            Destroy(g);
        }
    }
}