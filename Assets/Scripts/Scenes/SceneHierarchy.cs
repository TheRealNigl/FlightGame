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
    [ExecuteInEditMode][DisallowMultipleComponent]
    class SceneHierarchy : MonoBehaviour
    {
        #region strings
        
        /// <summary>
        /// 
        /// </summary>
        private static string[] sceneNames = { "Assets/Scenes/Flight.unity" };
        private static string[] SceneNames { get { return sceneNames; } set { } }

        #endregion

        #region Functionality

        /// <summary>
        /// 
        /// </summary>
        private static void Awake()
        {
            EditorApplication.delayCall += InitializeSceneHierarchy;
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
            for (int sceneLoadCount = 0; sceneLoadCount < SceneNames.Length; sceneLoadCount++)
            {
                EditorSceneManager.OpenScene(SceneNames[sceneLoadCount], OpenSceneMode.Additive);
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
