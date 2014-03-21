using UnityEngine;
using System.Collections;

public class SeekGUI : MonoBehaviour {

	void OnGUI() {
		GUI.Label (new Rect (0, 200, 200, 200), "Use WASD to move\nPress T to toggle targets\nPress F to transition to next state");
	}
}
