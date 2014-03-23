using UnityEngine;
using System.Collections;

public class player1 : MonoBehaviour {

	public float velocity;
	public Color startColor;
	
	void Awake ()
	{ startColor = renderer.material.color; }
	
	void FixedUpdate()
	{
		float x = 0;
		float y = 0;
		if(Input.GetKey(KeyCode.UpArrow))
			y = 1;
		else if(Input.GetKey(KeyCode.DownArrow))
			y = -1;
		else if(Input.GetKeyUp(KeyCode.UpArrow))
			y = 0;
		else if(Input.GetKeyUp(KeyCode.DownArrow))
			y = 0;

		if(Input.GetKey(KeyCode.LeftArrow))
			x = -1;
		else if(Input.GetKey(KeyCode.RightArrow))
			x = 1;
		else if(Input.GetKeyUp(KeyCode.RightArrow))
			x = 0;
		else if(Input.GetKeyUp(KeyCode.LeftArrow))
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
