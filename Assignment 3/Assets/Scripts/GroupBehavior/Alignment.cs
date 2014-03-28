using UnityEngine;
using System.Collections;

public class Alignment : MonoBehaviour {
	
	public float damping = .2f;
	public float groupRadius = 2.0f;
	public int behavioralPriority = 1;
	private static Vector3 averageVelocity = new Vector3();
	private PostUpdate postUpdater;
	// Use this for initialization
	void Start () 
	{
		postUpdater = gameObject.GetComponent<PostUpdate> ();
	}

	// Update is called once per frame
	void Update () 
	{
		GameObject[] boids = GameObject.FindGameObjectsWithTag ("Boid");
		averageVelocity = Vector3.zero;
		int groupCount = 0;
		foreach(GameObject boid in boids)
		{
			Vector3 v = boid.rigidbody.velocity;
			// don't count yourself as part of the group
			if(ReferenceEquals(boid,this.gameObject))
				continue;
			// don't count boids to far away as part of the group
			if(Vector3.Distance(this.transform.position,boid.transform.position) > groupRadius)
				continue;
			averageVelocity += v;
			groupCount++;
		}
		
		if (groupCount == 0 || groupCount == 1)
			return;
		averageVelocity /= groupCount;

		Vector3 velToSend = averageVelocity * damping;
		// send the change as a force to the post-updater
		behavStateDel bD = (o) => rigidbody.AddForce (velToSend);

		// send the direct velocity change to the post-updater
		//behavioralDelegate bD = () => rigidbody.velocity += velToSend;

		BehavioralEvent bE = new BehavioralEvent(bD,behavioralPriority);
		postUpdater.addEvent (bE);

	}

	
}
