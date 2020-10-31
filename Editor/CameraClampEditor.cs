
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CameraClamp))]
public class CameraClampEditor: Editor
{
    CameraClamp clamp;
    private void OnEnable()
    {
        clamp = target as CameraClamp; 
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        clamp.xMin = EditorGUILayout.FloatField("X Min",clamp.xMin);
        clamp.xMax = EditorGUILayout.FloatField("X Max", clamp.xMax);
        clamp.yMin = EditorGUILayout.FloatField("Y Min", clamp.yMin);
        clamp.yMax = EditorGUILayout.FloatField("Y Max", clamp.yMax);
    }   
}