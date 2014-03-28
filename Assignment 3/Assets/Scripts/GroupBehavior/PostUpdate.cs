using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

public class BehavioralEvent : IComparable
{
	private int priority;
	public int Priority {get {return priority;}}
	behavStateDel bD;

	public BehavioralEvent(behavStateDel _bD, int _priority)
	{
		bD = _bD;
		priority = _priority;
	}

	public void RUN()
	{
		bD.Invoke (null);
	}
	
	#region IComparable implementation
	public int CompareTo (object obj)
	{
		if (obj == null)
						return 1;

		BehavioralEvent other = obj as BehavioralEvent;

		if (other != null)
						return this.priority.CompareTo (other.priority);
				else
						throw new ArgumentException ("Object is not a VectorEvent");

	}
	#endregion
}


public class PostUpdate : MonoBehaviour {
	public float maxVel = 1f;
	public int priorityLevel = int.MaxValue;
	List<BehavioralEvent> toRun = new List<BehavioralEvent>();

	// Use this for initialization
	void Start () {
	
	}

	void LateUpdate () {	

		// run every event until we are higher than the priority value
		toRun.Sort ();
		foreach (BehavioralEvent e in toRun) 
		{
			if(e.Priority > priorityLevel)
				break;
			e.RUN ();
		}
		toRun.Clear ();

		// constrain velocity
		Vector3.ClampMagnitude (this.rigidbody.velocity, maxVel);

	}

	public void addEvent(BehavioralEvent bE)
	{		
		toRun.Add (bE);
	}



}


