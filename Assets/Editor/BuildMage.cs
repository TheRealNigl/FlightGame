using Assets.Editor;
using UnityEditor;
using UnityEngine;

public class BuildMage : EditorWindow
{
    [MenuItem("Tools/Build Mage")]
    private static void Init()
    {
        BuildMage window = (BuildMage)EditorWindow.GetWindow(typeof(BuildMage));
        window.Show();
    }

    private void OnGui()
    {
        GUILayout.FlexibleSpace();
        GUILayout.BeginHorizontal();
        EditorGUILayout.TextField("Hello");
        if (GUILayout.Button("Build"))
        {
            Build.build.BuildProject();
        }
        GUILayout.EndHorizontal();
    }
}
