using UnityEngine;
using System.Collections;

public class PonBall : MonoBehaviour {

	// Use this for initialization
	void Start () {
        rigidbody.AddForce(Vector3.right * 100.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollision(Collider other)
    {
        rigidbody.velocity = -rigidbody.velocity;
    }
}
