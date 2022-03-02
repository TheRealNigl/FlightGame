/// Title of class:
///     Score
///     
/// Description:
///     Handles the players score
///
/// Author: Alex Nigl

using UnityEngine;

public class Score : MonoBehaviour
{
    public static int PlayerScore { get; private set; }

    public static void Start()
    {
        PlayerScore = 0;
    }

    /// <summary>
    /// By default adds one score, override for additional score
    /// </summary>
    /// <param name="score"></param>
    public static void IncrementScore(int score = 1)
    {
        PlayerScore += score;
    }

    /// <summary>
    /// By default removes once score, override for additional score.
    /// Use positive values. 
    /// </summary>
    /// <param name="score"></param>
    public static void DecrementScore(int score = 1)
    {
        PlayerScore -= score;
    }
}
