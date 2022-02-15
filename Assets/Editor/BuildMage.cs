using UnityEditor;
using UnityEngine;

namespace Assets.Editor
{
    public class BuildMage : EditorWindow
    {
        [MenuItem("Tools/Build Mage")]
        static void init()
        {
            // Get existing open window or if none, make a new one:
            BuildMage window = (BuildMage)GetWindow(typeof(BuildMage));
            window.Show();
        }

        void OnGui()
        {
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Build"))
            {
                Build.build.BuildProject();
            }
            EditorGUILayout.EndHorizontal();
        }
    }
}
