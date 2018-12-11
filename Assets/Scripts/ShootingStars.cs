using System.Collections;
using UnityEngine;

public class ShootingStars : MonoBehaviour
{
    private GameObject star;
    private GameObject[] stars;
    private int LowSpawnCount { get; set; }
    private int HighSpawnCount { get; set; }
    private int SpawnCount { get; set; }

    private void Start() {
        star = Resources.Load("Star") as GameObject;
        LowSpawnCount = RandomHelper.ReturnRandom(1, 2);
        HighSpawnCount = RandomHelper.ReturnRandom(4, 5);
        SpawnCount = RandomHelper.ReturnRandom(LowSpawnCount, HighSpawnCount);
        stars = new GameObject[SpawnCount];
        SpawnStars();
    }
    
    private void SpawnStars() {
        do {
            StartCoroutine("LimitSpawnRate", SpawnCount);
            SpawnCount--;
        } while (SpawnCount >= 0);
    }

    IEnumerable LimitSpawnRate(int count) {
        yield return new WaitForSeconds(RandomHelper.ReturnRandom(2, 5));
        stars[count] = Instantiate(star);
        switch (RandomHelper.ReturnRandom(1, 2)) {
            case 1:
                stars[count].GetComponent<Star>().AddForceWithDirection(new Vector2(RandomHelper.ReturnRandom(-1, 0), RandomHelper.ReturnRandom(-1, 0)));
                break;
            case 2:
                stars[count].GetComponent<Star>().AddForceWithDirectionAndSpeed(new Vector2(RandomHelper.ReturnRandom(-1, 0),
                                                                                                 RandomHelper.ReturnRandom(-1, 0)), 
                                                                                                 RandomHelper.ReturnFloat(3, 10));
                break;
            default:
                break;
        }
    }
}