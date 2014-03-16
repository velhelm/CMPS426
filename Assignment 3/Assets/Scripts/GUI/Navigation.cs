using UnityEngine;
using System.Collections;

public class Navigation : MonoBehaviour {
    private float AREA_LEFT = Screen.width - Screen.width / 5;
    private float AREA_TOP = 20;
    private float AREA_HEIGHT = Screen.height - 60;
    private float AREA_WIDTH = Screen.width / 5 - 20;

    //private Vector2 nativeResolution, scale;

    void OnAwake()
    {
        //nativeResolution.x = Screen.width;
        //nativeResolution.y = Screen.height;
    }

    void OnGUI()
    {
        //scale.x = Screen.width / nativeResolution.x;
        //scale.y = Screen.height / nativeResolution.y;

        //var previousMatrix = GUI.matrix;
        //GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);

        GUI.Box(new Rect(AREA_LEFT, AREA_TOP, AREA_WIDTH, AREA_HEIGHT + 20), "Navigation");

        GUILayout.BeginArea(new Rect(AREA_LEFT, AREA_TOP + 20, AREA_WIDTH, AREA_HEIGHT));

        GUILayout.BeginVertical();

        if (GUILayout.Button("Main Menu", GUILayout.Height(AREA_HEIGHT / 6.5f))) Application.LoadLevel("Main");
        if (GUILayout.Button("Waypoint Steering", GUILayout.Height(AREA_HEIGHT / 6.5f))) Application.LoadLevel("WaypointSteering");
        if (GUILayout.Button("Advanced Waypoint Steering", GUILayout.Height(AREA_HEIGHT / 6.5f))) Application.LoadLevel("AdvancedWaypointSteering");
        if (GUILayout.Button("Evasive Steering", GUILayout.Height(AREA_HEIGHT / 6.5f))) Application.LoadLevel("EvasiveSteering");
        if (GUILayout.Button("Other Steering", GUILayout.Height(AREA_HEIGHT / 6.5f))) Application.LoadLevel("OtherSteering");
        if (GUILayout.Button("Group Behaviors", GUILayout.Height(AREA_HEIGHT / 6.5f))) Application.LoadLevel("GroupBehaviors");

        GUILayout.EndVertical();

        GUILayout.EndArea();

        //GUI.matrix = previousMatrix;
    }
}
