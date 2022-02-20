/// Title of class:
///     
///     
/// Description:
///     
///
/// Author: Alex Nigl

using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Editor
{
    class SceneHierarchy : MonoBehaviour
    {
        #region strings
        
        /// <summary>
        /// 
        /// </summary>
        private static string[] scenePaths = { "Assets/Scenes/Main.unity",
                                               "Assets/Scenes/UI.unity",
                                               "Assets/Scenes/Game.unity", };
        private static string[] ScenePaths { get { return scenePaths; } set { } }

        #endregion

        #region Functionality

        /// <summary>
        /// 
        /// </summary>
        [MenuItem("Tools/Reload Scenes")]
        [InitializeOnLoadMethod]
        private static void Awake()
        {
            if(!EditorApplication.isPlayingOrWillChangePlaymode)
            {
                EditorApplication.delayCall += InitializeSceneHierarchy;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        
        public static void InitializeSceneHierarchy()
        {
            EditorApplication.delayCall -= InitializeSceneHierarchy;

            RemoveCurrentSceneHierarchy();
            SetSceneHierarchy();
            Debug.Log("Initialized Set Scene Hierarchy.");
        }

        /// <summary>
        /// 
        /// </summary>
        private static void SetSceneHierarchy()
        {
            for (int sceneLoadCount = 0; sceneLoadCount < ScenePaths.Length; sceneLoadCount++)
            {
                EditorSceneManager.OpenScene(ScenePaths[sceneLoadCount], OpenSceneMode.Additive);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private static void RemoveCurrentSceneHierarchy()
        {
            for (int currentSceneCount = 1; currentSceneCount < SceneManager.sceneCount; currentSceneCount++)
            {
                EditorSceneManager.CloseScene(SceneManager.GetSceneAt(currentSceneCount), true);
            }
        }

        #endregion
    }
}
