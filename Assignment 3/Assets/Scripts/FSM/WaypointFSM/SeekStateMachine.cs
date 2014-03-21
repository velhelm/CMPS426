using UnityEngine;
using System.Collections;

public class SeekStateMachine : AbstractStateMachine {

	/// <summary>
	/// Essentially the same as the base update, except this one
	/// uses wrap-around for illegal transitions.
	/// </summary>
	public override void Update () {
		// Update current state.
		base.currentState.Update();
		
		// Check for transition.
		int newId = base.currentState.CheckTransition();

		//Force wrap-around
		if (newId > base.states.Count-1)
		{ newId = 0; }

		// Make transition if required.
		if (currentState.ID != newId)
		{
			base.Transition(newId);
		}
	}
}
