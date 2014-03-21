using UnityEngine;
using System.Collections;

/// <summary>
/// All the player object needs to do is respond to movement.
/// As such, there's no point in making it part of the state machine.
/// </summary>
public class PlayerControl : MonoBehaviour {
    public float velocity;
	public Color startColor;

	void Awake ()
	{ startColor = renderer.material.color; }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(x, y, 0.0f);
        movement = movement * velocity;
        
        rigidbody.velocity = movement * velocity;

        /* Distance from origin to top and bottom bounds
         * is the same.
         */
        if (Mathf.Abs(transform.position.y) > Bounds.Y_MAX)
        {
            float newY = -transform.position.y;
            transform.position = new Vector3(transform.position.x, newY, 0.0f);
        }

        if (transform.position.x > Bounds.X_MAX)
        {
            transform.position = new Vector3(Bounds.X_MIN, transform.position.y, 0.0f);
        }
        else if (transform.position.x < Bounds.X_MIN)
        {
            transform.position = new Vector3(Bounds.X_MAX, transform.position.y, 0.0f);
        }

		//Color differentiation used in seek
		if (renderer.material.color != Color.black 
		    && renderer.material.color != Color.grey
		    && renderer.material.color != startColor) 
		{ renderer.material.color = startColor; }
    }
}
