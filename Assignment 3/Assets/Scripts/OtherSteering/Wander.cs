using UnityEngine;
using System.Collections;
using Holoville.HOTween;



public class Wander : MonoBehaviour {
	public float radius = 2.0f;
	public float minJit = -180.0f;
	public float maxJit = 180.0f;

	public float speed = 5.0f;

	private bool moving = false;
	public GameObject carrot = null;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(carrot == null) return;
		if(moving) return;

		float r = Random.Range(minJit,maxJit);

		carrot.transform.RotateAround(transform.position,Vector3.up,r);

		Vector3 target = carrot.transform.position;
		startTransfer(target);

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
		moving = false;
	}
}
