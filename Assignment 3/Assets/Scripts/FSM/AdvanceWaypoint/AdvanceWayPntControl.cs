using UnityEngine;
using System.Collections;

public class AdvanceWayPntControl : AbstractControl {
	public float speed;

	public enum States
	{
		INTERPOSE
	}

	public override StateMachine CreateMachine()
	{
		StateMachine machine = new StateMachine();
		machine.AddDefaultState(new InterposeState((int)States.INTERPOSE, this));
		return machine;
	}

	public override void GlobalUpdate()
	{
		if (Mathf.Abs(transform.position.y) > Bounds.Y_MAX)
		{
			float newY = -transform.position.y;
			transform.position = new Vector3(transform.position.x, newY, 0.0f);
		}
		
		if (transform.position.x > Bounds.X_MAX)
		{
			transform.position = new Vector3(Bounds.X_MIN, transform.position.y, 0.0f);
		}
		else if (transform.position.x < Bounds.X_MIN)
		{
			transform.position = new Vector3(Bounds.X_MAX, transform.position.y, 0.0f);
		}
	}

	public GameObject GetPlayer1()
	{
		return GameObject.FindGameObjectWithTag("Player1");
	}

	public GameObject GetPlayer2()
	{
		return GameObject.FindGameObjectWithTag("Player2");
	}
}
