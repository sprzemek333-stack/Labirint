using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.TerrainTools;
using UnityEngine;
[CustomEditor(typeof(LevelGenerator))]
public class LevelGenearatorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        LevelGenerator generator = (LevelGenerator)target;

        if (GUILayout.Button("Create Level"))
        {
            generator.GenerateLevel();
        }

    }
}
