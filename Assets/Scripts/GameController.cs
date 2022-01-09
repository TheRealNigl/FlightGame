using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static int Score;
    public static GameController Instance;
    public GameObject GameOvertext;
    public GameObject ScoreObject;
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;
    public GameObject Button4;
    public GameObject InputField1;
    public GameObject ResultsText;

    public Text scoreText;
    public GameObject Asteroid;

    public float scrollSpeed { get; set; }
    
    public void Start() {
        scoreText = ScoreObject.GetComponent<Text>();
        Score = 0;
        scrollSpeed = -3f;
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameStart() {
        Score = 0;
        scoreText.text = "Score: " + Score.ToString();
        GameOvertext.SetActive(false);
        Button1.SetActive(false);
        Button2.SetActive(false);
        Button3.SetActive(false);
        Button4.SetActive(false);
        InputField1.SetActive(false);
        ResultsText.SetActive(false);
        GetComponent<PlanetPool>().SpawnObjects();
        GetComponent<ShootingStars>().SpawnObjects();
    }

    public void PlayerScored() {
        Score++;
        scoreText.text = "Score: " + Score.ToString();
    }

    public void PlayerDied() {
        GetComponent<PlanetPool>().Despawn();
        GetComponent<ShootingStars>().Despawn();
        scoreText.text = "Score: " + Score.ToString();
        GameOvertext.SetActive(true);
        Button1.SetActive(true);
        Button2.SetActive(true);
        Button3.SetActive(true);
        Button4.SetActive(true);
        InputField1.SetActive(true);
        ResultsText.SetActive(true);
    }
}