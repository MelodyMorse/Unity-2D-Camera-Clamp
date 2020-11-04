using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CameraClamp))]
public class CameraClampEditor: Editor
{
    CameraClamp clamp;
    float snap = .01f;
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
    private void OnSceneGUI()
    {
        Vector3 pos = clamp.transform.position;
        
        clamp.xMax = Handles.FreeMoveHandle(new Vector3(clamp.xMax, pos.y, pos.z), clamp.transform.rotation, .2f, new Vector3(snap, snap), Handles.CubeHandleCap).x;
        clamp.xMin = Handles.FreeMoveHandle(new Vector3(clamp.xMin, pos.y, pos.z), clamp.transform.rotation,.2f, new Vector3(snap, snap), Handles.CubeHandleCap).x;
        clamp.yMax = Handles.FreeMoveHandle(new Vector3(pos.x, clamp.yMax, pos.z), clamp.transform.rotation, .2f, new Vector3(snap, snap), Handles.CubeHandleCap).y;
        clamp.yMin = Handles.FreeMoveHandle(new Vector3(pos.x, clamp.yMin, pos.z), clamp.transform.rotation, .2f, new Vector3(snap, snap), Handles.CubeHandleCap).y;
    }
}