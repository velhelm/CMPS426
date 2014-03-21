using UnityEngine;
using System.Collections;

/// <summary>
/// Idle state.
/// This state transitions to the next state when F is pressed
/// </summary>
public class IdleState : AbstractState {
	private int transitionID;

	#region methods
	public IdleState(int id, AbstractControl controller) : base(id, controller)
	{ transitionID = ID; }

	public override void Enter() {
		Debug.Log ("Entering Idle State");
		name = "Idle";
	}

	public override void Update() {
		//Remove all velocity
		Controller.rigidbody.velocity = Vector3.zero;

		//Transition to next state if F is pressed
		if (Input.GetKeyDown (KeyCode.F)) {
			transitionID = ID + 1;
		}
		else {
			transitionID = ID;
		}
	}

	public override void FixedUpdate() { }

	public override void Exit() {
		Debug.Log ("Exiting Idle State");
	}

	public override int CheckTransition() {
		return transitionID;
	}
	#endregion
}
