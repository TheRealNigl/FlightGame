/// Title of class:
///
/// Description:
///     
///
/// Author: Alex Nigl

using UnityEngine;

public class GameController : MonoBehaviour
{
    /// <summary>
    /// Instance of the Game Controller
    /// </summary>
    public static GameController Instance;

    /// <summary>
    /// Velocity of enemies
    /// </summary>
    [SerializeField]
    public float scrollSpeed;
    
    /// <summary>
    /// 
    /// </summary>
    public void Start() 
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void StartGame() 
    {
        swapStateOfGame(true);
    }

    /// <summary>
    /// 
    /// </summary>
    public void PlayerDied() 
    {
        swapStateOfGame();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="gameStart"></param>
    private void swapStateOfGame(bool gameStart = false)
    {
        if (gameStart)
        {
            GetComponent<PlanetPool>().SpawnObjects();
            GetComponent<ShootingStars>().SpawnObjects();
            GetComponent<StarTwinkle>().Despawn();
        }
        else
        {
            GetComponent<PlanetPool>().Despawn();
            GetComponent<ShootingStars>().Despawn();
            GetComponent<StarTwinkle>().SpawnObjects();
        }
    }
}