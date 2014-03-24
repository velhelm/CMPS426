using UnityEngine;
using System.Collections;

public class Seek : MonoBehaviour {
	public Vector3 target = Vector3.zero;
	public float forceVal = 5;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
	void FixedUpdate()
	{
		Vector3 towards = Vector3.Normalize (target - transform.position);
		rigidbody.AddForce (towards * forceVal);
	}
	
}
