using UnityEngine;
using System.Collections;

public class SeekGUI : MonoBehaviour {

	void OnGUI() {
		GUI.Label (new Rect (0, 200, 200, 200), "Use WASD to move\nPress F to toggle targets\nPress G to return to idle state");
	}
}
