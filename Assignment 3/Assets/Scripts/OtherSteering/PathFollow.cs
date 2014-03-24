using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class PathFollow : MonoBehaviour {
	public WayPoint current = null;
	public float speed = 1;
	private bool moving = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update()
	{
		// if no path do nothing
		if (current == null || current.Next == null)
			return;
		// if moving do nothing
		if (moving)
						return;

		// start finding target
		Vector3 cpos = current.transform.position;
		Vector3 npos = current.Next.transform.position;
		Ray ray = new Ray(cpos,npos-cpos);
		// only hit player tag
		int layerMask = 1 << 8;

		// here we choose between the next point or the nearest point on the path
		Vector3 target = Physics.Raycast (ray, layerMask) ? current.transform.position : closestPoint ();
		// end finding target

		startTransfer (target);

	}

	private void startTransfer(Vector3 target)
	{
		moving = true;
		TweenParms parms = new TweenParms ();
		parms.Prop ("position", target);
		parms.OnComplete (endTransfer);
		parms.Ease (EaseType.Linear);
		float moveTime = Vector3.Magnitude (transform.position - target) / speed;
		HOTween.To (transform, moveTime, parms);
	}

	private void endTransfer(TweenEvent data)
	{
		current = current.Next;
		moving = false;
	}
	Vector3 closestPoint()
	{
		Vector3 A = current.transform.position;
		Vector3 B = current.Next.transform.position;
		Vector3 P = transform.position;

		Vector3 AP = P - A;
		Vector3 AB = B - A;

		float ab2 = AB.x*AB.x + AB.y*AB.y;
		float ap_ab = AP.x*AB.x + AP.y*AB.y;
		float t = ap_ab / ab2;

		if (t < 0.0f) t = 0.0f;
		else if (t > 1.0f) t = 1.0f;

		Vector3 Closest = A + AB * t;
		return Closest;

	}
}
