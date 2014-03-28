using UnityEngine;
using System.Collections;

public delegate void behavStateDel(GameObject other);

public class States : MonoBehaviour {


	private behavStateDel DefaultState;
	private behavStateDel PursuitState;


	// Use this for initialization
	void Start () {/*
		DefaultState = (o) => 
		{
			this.GetComponent<Pursuit> ().enabled = false;
			this.GetComponent<Seek> ().enabled = false;
		};
		PursuitState = (o) =>
		{
			this.GetComponent<Pursuit> ().target = o;
			this.GetComponent<Pursuit> ().enabled = true;
			this.GetComponent<Seek> ().enabled = false;
		};
		DefaultState.Invoke (null);

*/
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate()
	{

	}

	public void defaultBehavior()
	{
		DefaultState.Invoke (null);
	}

	public void pursue(GameObject target)
	{
		PursuitState.Invoke (target);
	}
}
