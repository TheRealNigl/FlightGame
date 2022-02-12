/// Title of class:
///
/// Description:
///     
///
/// Author: Alex Nigl

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    private bool GameStart = false;

    /// <summary>
    /// 
    /// </summary>
    public static int Score;

    /// <summary>
    /// 
    /// </summary>
    public static GameController Instance;

    /// <summary>
    /// 
    /// </summary>
    public GameObject GameOvertext;

    /// <summary>
    /// 
    /// </summary>
    public GameObject ScoreObject;

    /// <summary>
    /// 
    /// </summary>
    public GameObject InputField1;

    /// <summary>
    /// 
    /// </summary>
    public GameObject ResultsText;

    /// <summary>
    /// 
    /// </summary>
    public Text scoreText;

    /// <summary>
    /// 
    /// </summary>
    public GameObject Asteroid;

    /// <summary>
    /// 
    /// </summary>
    public float scrollSpeed { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public void Start() 
    {
        scoreText = ScoreObject.GetComponent<Text>();
        Score = 0;
        scrollSpeed = -3f;

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
    public void Restart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
    public void PlayerScored() 
    {
        Score++;
        scoreText.text = "score: " + Score.ToString();
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
            Score = 0;
            scoreText.text = "score: " + Score.ToString();
            GameOvertext.SetActive(false);
            InputField1.SetActive(false);
            ResultsText.SetActive(false);
            GetComponent<PlanetPool>().SpawnObjects();
            GetComponent<ShootingStars>().SpawnObjects();
        }
        else
        {
            GetComponent<PlanetPool>().Despawn();
            GetComponent<ShootingStars>().Despawn();
            scoreText.text = "score: " + Score.ToString();
            GameOvertext.SetActive(true);
            InputField1.SetActive(true);
            ResultsText.SetActive(true);
        }
    }
}