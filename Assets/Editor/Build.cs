/// Title of class:
///     
///     
/// Description:
///     
///
/// Author: Alex Nigl
/// 

using UnityEditor;

namespace Assets.Editor
{
    public class Build
    {
        public static Build build { get; set; }

        /// <summary>
        /// The sequential order to initiate the target build
        /// </summary>
        public static void BuildProject()
        {
            SceneHierarchy.InitializeSceneHierarchy();

            CallUnityBuildTrigger();
        }

        private static void CallUnityBuildTrigger()
        {
            //BuildPipeline.BuildPlayer();
        }
    }
}
