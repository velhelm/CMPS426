using UnityEngine;
using System.Collections;

public class Navigation : MonoBehaviour {
    
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

		float AREA_LEFT = Screen.width - Screen.width / 5;
		float AREA_TOP = 20;
		float AREA_HEIGHT = Screen.height - 60;
		float AREA_WIDTH = Screen.width / 5 - 20;

		GUIStyle wrapStyle = new GUIStyle("Button");
		wrapStyle.wordWrap = true;

        GUI.Box(new Rect(AREA_LEFT, AREA_TOP, AREA_WIDTH, AREA_HEIGHT + 20), "Navigation");

        GUILayout.BeginArea(new Rect(AREA_LEFT, AREA_TOP + 20, AREA_WIDTH, AREA_HEIGHT));

        GUILayout.BeginVertical();

        if (GUILayout.Button("Main Menu", wrapStyle, GUILayout.Height(AREA_HEIGHT / 6.5f))) Application.LoadLevel("Main");
		if (GUILayout.Button("Waypoint Steering", wrapStyle, GUILayout.Height(AREA_HEIGHT / 6.5f))) Application.LoadLevel("WaypointSteering");
		if (GUILayout.Button("Advanced Waypoint Steering", wrapStyle, GUILayout.Height(AREA_HEIGHT / 6.5f))) Application.LoadLevel("AdvancedWaypointSteering");
		if (GUILayout.Button("Evasive Steering", wrapStyle, GUILayout.Height(AREA_HEIGHT / 6.5f))) Application.LoadLevel("EvasiveSteering");
		if (GUILayout.Button("Other Steering", wrapStyle, GUILayout.Height(AREA_HEIGHT / 6.5f))) Application.LoadLevel("OtherSteering");
		if (GUILayout.Button("Group Behaviors", wrapStyle, GUILayout.Height(AREA_HEIGHT / 6.5f))) Application.LoadLevel("GroupBehaviors");

        GUILayout.EndVertical();

        GUILayout.EndArea();

        //GUI.matrix = previousMatrix;
    }
}
