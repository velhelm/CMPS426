using UnityEngine;
using System.Collections;

public class Separation : MonoBehaviour {

	public float forceVal = 5f;
	public float minDistance = 2.0f;
	public int behavioralPriority = 1;
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
		foreach(GameObject other in boids)
		{
			if(other == this.gameObject)
				continue;
			Vector3 otherPos = other.transform.position;
			behavStateDel bD = (o) => rigidbody.AddExplosionForce(forceVal,otherPos,minDistance);
			BehavioralEvent bE = new BehavioralEvent(bD,behavioralPriority);
						
			postUpdater.addEvent(bE);
		}
	}


}
