using UnityEngine;

public class RandomHelper : MonoBehaviour
{
    public static int ReturnRandom(int low, int high)
    {
        return Random.Range(low, high);
    }

    public static float ReturnFloat(float low, float high)
    {
        return Random.Range(low, high);
    }
}
