using UnityEngine;
using System.Collections;

public class PathEdit : MonoBehaviour {

	public GameObject ghost = null;
	public GameObject point = null;
	public GameObject pointMan = null;

	private Collider pCol;
	private Vector3 currentPos;
	private Camera cam;
	// Use this for initialization
	void Start () {
		pCol = GameObject.Find ("Plane").collider;
		cam = GameObject.Find ("Main Camera").GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (point == null)
						return;

		// get ray
		Ray ray = cam.ScreenPointToRay(Input.mousePosition);
		// get pos on plane
		RaycastHit hit;
		if(!pCol.Raycast (ray, out hit, float.MaxValue))
			return;

		currentPos = ray.GetPoint (hit.distance);
		currentPos.y = 0;

		if (Input.GetMouseButtonDown (0)) 
		{
			GameObject g = (GameObject)GameObject.Instantiate (point, currentPos, Quaternion.identity);
			if(pointMan != null)
				pointMan.GetComponent<PathFollow>().current = g.GetComponent<WayPoint>();
		}

		// move ghost
		if (ghost == null)
			return;

		// set pos of ghost to pos on plane
		ghost.transform.position = currentPos;
	}
}
