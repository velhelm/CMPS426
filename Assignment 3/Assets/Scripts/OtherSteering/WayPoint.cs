using UnityEngine;
using System.Collections;

public class WayPoint : MonoBehaviour {
	private static WayPoint prevSet = null;
	private static WayPoint firstSet = null;
	private WayPoint prev = null;
	private WayPoint next = null;

	public WayPoint Next {get {	return next;}}
	public WayPoint Prev {get {	return prev;}}

	private LineRenderer lRend;

	public float lineYOffset = .75f;

	// Use this for initialization
	void Start () {
		lRend = gameObject.GetComponent<LineRenderer> ();
		if (prevSet != null) 
		{
			prev = prevSet;
			prev.next = this;
			makeLine();
		}
		if (firstSet == null)
			firstSet = this;
		else
			firstSet.closeLoop(this);

		prevSet = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	private void makeLine()
	{
		Vector3 v1 = prev.transform.position;
		Vector3 v2 = transform.position;
		v1.y += lineYOffset;
		v2.y += lineYOffset;

		lRend.SetPosition (0, v1);
		lRend.SetPosition (1, v2);
		lRend.enabled = true;
	}

	private void closeLoop(WayPoint other)
	{
		prev = other;
		prev.next = this;

		makeLine ();
	}

	public void newPath()
	{
		prevSet = null;
		firstSet = null;
	}
}
