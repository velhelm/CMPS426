using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SeekState : AbstractState {
	#region variables
	private int transitionID;

	private List<GameObject> objectsToSeek = new List<GameObject>();
	private int currentWaypoint = 0;
	#endregion

	#region methods
	public SeekState(int id, AbstractControl controller) : base(id, controller)
	{ transitionID = ID; }
	
	public override void Enter() {
		Debug.Log ("Entering Seek State");

		//Add all waypoints to the list
		foreach (GameObject gO in GameObject.FindGameObjectsWithTag("Waypoint")) {
			objectsToSeek.Add(gO);
		}

		objectsToSeek[currentWaypoint].renderer.material.color = Color.black;
	}
	
	public override void Update() {
		//Switch through the current targets as F is pressed
		if (Input.GetKeyDown (KeyCode.F)) {
			objectsToSeek[currentWaypoint].renderer.material.color = Color.blue;
			currentWaypoint++;
			if (currentWaypoint >=objectsToSeek.Count) {
				currentWaypoint = 0;
			}
			objectsToSeek[currentWaypoint].renderer.material.color = Color.black;
		}

		if (Input.GetKeyDown (KeyCode.G)) 
		{ transitionID = ID + 1; }
		else 
		{transitionID = ID; }
	}
	
	public override void FixedUpdate() {
		if (Controller.transform.position != objectsToSeek [currentWaypoint].transform.position) {
			Controller.rigidbody.AddForce(objectsToSeek[currentWaypoint].transform.position -Controller.transform.position);
		}
		
	}
	
	public override void Exit() {
		Debug.Log ("Exiting Seek State");
	}	
	
	public override int CheckTransition(){
		return transitionID;
	}
	#endregion
}
