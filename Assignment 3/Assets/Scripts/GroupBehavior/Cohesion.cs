using UnityEngine;
using System.Collections;

public class Cohesion : MonoBehaviour {

	public float forceVal = 5f;
	public float targetRadius = 2.0f;
	public float groupRadius = 5.0f;
	public int behavioralPriority = 1;
	private Vector3 centerOfMass = new Vector3();
	private PostUpdate postUpdater;
	// Use this for initialization
	void Start () 
	{
		postUpdater = this.gameObject.GetComponent<PostUpdate> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		GameObject[] boids = GameObject.FindGameObjectsWithTag ("Boid");
		centerOfMass = Vector3.zero;
		int groupCount = 0;

		foreach(GameObject boid in boids)
		{
			if(Vector3.Distance(this.transform.position,boid.transform.position) > groupRadius)
				continue;
			centerOfMass += boid.transform.position;
			groupCount++;
		}
		if (groupCount == 0 || groupCount == 1) {
						return;
				}
		centerOfMass /= (float)groupCount;
		float dist = Vector3.Distance (centerOfMass, this.transform.position);
		BehavioralEvent bE = null;
		if (dist > targetRadius)
						bE = new BehavioralEvent ((o) => rigidbody.AddExplosionForce (-forceVal, centerOfMass, dist + 0.1f), behavioralPriority);
		if (bE != null)
						postUpdater.addEvent (bE);
	}
	
	void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere (centerOfMass, 1);
	}
}
