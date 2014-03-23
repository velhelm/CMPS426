using UnityEngine;
using System.Collections;

public class InterposeState : AbstractState {
	Transform transform;
	GameObject player1, player2;
	Rigidbody rigidbody;
	int direction_x, direction_y, direction_z;

	public InterposeState(int id, AbstractControl control)
		: base(id, control) { }

	public override void Enter()
	{
		player1 = ((AdvanceWayPntControl)Controller).GetPlayer1();
		player2 = ((AdvanceWayPntControl)Controller).GetPlayer2();
		transform = ((AdvanceWayPntControl)Controller).transform;
		rigidbody = Controller.rigidbody;
	}
	
	public override void Exit()
	{
		player1 = null;
		player2 = null;
		rigidbody = null;
	}
	
	public override void Update() { }
	
	public override void FixedUpdate()
	{
		Vector3 tempVector;
		tempVector.x = (player1.transform.position.x + player2.transform.position.x) / 2;
		tempVector.y = (player1.transform.position.y + player2.transform.position.y) / 2;
		tempVector.z = (player1.transform.position.z + player2.transform.position.z) / 2;
		Vector3 velocity = Vector3.zero;
		
		if(transform.position.x < tempVector.x)
			direction_x = 1;
		else
			direction_x = -1;
		
		if(transform.position.y < tempVector.y)
			direction_y = 1;
		else
			direction_y = -1;
		
		if(transform.position.z < tempVector.z)
			direction_z = 1;
		else
			direction_z = -1;
		
		if(Mathf.Abs(tempVector.x - transform.position.x) > 10)
		{
			velocity.x = 3.0f * direction_x;
		}
		else if(Mathf.Abs(tempVector.x - transform.position.x) > 3 && Mathf.Abs(tempVector.x - transform.position.x) <= 10)
		{
			velocity.x = 2.0f * direction_x;
		}
		else if(Mathf.Abs(tempVector.x - transform.position.x) <= 3 && Mathf.Abs(tempVector.x - transform.position.x) > .01)
			velocity.x = direction_x;
		else
		{
			velocity.x = 0;
			Vector3 placeIt = transform.position;
			placeIt.x = tempVector.x;
			transform.position = placeIt;
		}
		
		if(Mathf.Abs(tempVector.y - transform.position.y) > 10)
		{
			velocity.y = 3.0f * direction_y;
		}
		else if(Mathf.Abs(tempVector.y - transform.position.y) > 3 && Mathf.Abs(tempVector.y - transform.position.y) <= 10)
		{
			velocity.y = 2.0f * direction_y;
		}
		else if(Mathf.Abs(tempVector.y - transform.position.y) <= 3 && Mathf.Abs(tempVector.y - transform.position.y) > .01)
			velocity.y = direction_y;
		else
		{
			velocity.y = 0;
			Vector3 placeIt = transform.position;
			placeIt.y = tempVector.y;
			transform.position = placeIt;
		}
		
		if(Mathf.Abs(tempVector.z - transform.position.z) > 10)
		{
			velocity.z = 3.0f * direction_z;
		}
		else if(Mathf.Abs(tempVector.z - transform.position.z) > 3 && Mathf.Abs(tempVector.z - transform.position.z) <= 10)
		{
			velocity.z = 2.0f * direction_z;
		}
		else if(Mathf.Abs(tempVector.z - transform.position.z) <= 3 && Mathf.Abs(tempVector.z - transform.position.z) > .01)
			velocity.z = direction_z;
		else
		{
			velocity.z = 0;
			Vector3 placeIt = transform.position;
			placeIt.z = tempVector.z;
			transform.position = placeIt;
		}

		rigidbody.velocity = velocity;
	}
	
	public override int CheckTransition() { return ID; }


}
