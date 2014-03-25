using UnityEngine;
using System.Collections;

public class player2 : MonoBehaviour {

	public float velocity;
	public Color startColor;
	
	void Awake ()
	{ startColor = renderer.material.color; }
	
	void FixedUpdate()
	{
		float x = 0;
		float y = 0;
		if(Input.GetKey(KeyCode.W))
			y = 1;
		else if(Input.GetKey(KeyCode.S))
			y = -1;
		else if(Input.GetKeyUp(KeyCode.W))
			y = 0;
		else if(Input.GetKeyUp(KeyCode.S))
			y = 0;
		
		if(Input.GetKey(KeyCode.A))
			x = -1;
		else if(Input.GetKey(KeyCode.D))
			x = 1;
		else if(Input.GetKeyUp(KeyCode.D))
			x = 0;
		else if(Input.GetKeyUp(KeyCode.A))
			x = 0;
		
		Vector3 movement = new Vector3(x, y, 0.0f);
		movement = movement * velocity;
		
		rigidbody.velocity = movement * velocity;
		
		/* Distance from origin to top and bottom bounds
         * is the same.
         */
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
}
