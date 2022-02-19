using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Scenes", menuName = "ScriptableObjects/Scenes", order = 1)]
public class Scenes : ScriptableObject
{
    public Scene[] scenes;
}