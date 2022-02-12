/// Title of class:
///
/// Description:
///     
///
/// Author: Alex Nigl


using UnityEngine;

public class RandomHelper : MonoBehaviour
{
    /// <summary>
    /// Random int
    /// </summary>
    /// <param name="low"></param>
    /// <param name="high"></param>
    /// <returns></returns>
    public static int ReturnRandom(int low, int high)
    {
        return Random.Range(low, high);
    }

    /// <summary>
    /// Random float
    /// </summary>
    /// <param name="low"></param>
    /// <param name="high"></param>
    /// <returns></returns>
    public static float ReturnFloat(float low, float high)
    {
        return Random.Range(low, high);
    }
}
