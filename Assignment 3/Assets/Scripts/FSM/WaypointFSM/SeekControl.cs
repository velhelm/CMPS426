using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SeekControl : AbstractControl {

	public void Awake() {
		AbstractState idle = new IdleState (0, this);
		AbstractState seek = new SeekState (1, this);

		stateMachine = new SeekStateMachine ();
		stateMachine.AddDefaultState (idle);
		stateMachine.AddState (seek);
	}
}
