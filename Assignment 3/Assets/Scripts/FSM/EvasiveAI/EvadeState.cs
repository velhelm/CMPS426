using UnityEngine;
using System.Collections;

public class EvadeState : AbstractState {
    Transform player, position;
    Rigidbody playerRigidbody, rigidbody;
    GameObject waypoint;

    public EvadeState(int id, AbstractControl control)
        : base(id, control) 
    {
        waypoint = GameObject.FindGameObjectWithTag("Waypoint");
    }

    public override void Enter()
    {
        player = ((EvasiveAIControl)Controller).GetPlayerTransform();
        position = Controller.transform;
        playerRigidbody = ((EvasiveAIControl)Controller).GetPlayerRigidbody();
        rigidbody = Controller.rigidbody;

        // Enable the waypoint marker.
        waypoint.SetActive(true);

        GameObject.FindGameObjectWithTag("StateHeader").GetComponent<GUIText>().text = "Evade State";
    }

    public override void Exit()
    {
        player = null;
        position = null;
        playerRigidbody = null;
        rigidbody = null;

        waypoint.SetActive(false);
    }

    public override void Update() { }

    public override void FixedUpdate()
    {
        Vector3 toPursuer = player.position - position.position;
        
        // Look ahead time is proportional to the distance between the pursuer and evader.
        // It is inversely proportional to the sum of the agents velocities.
        float lookAheadTime = toPursuer.magnitude / (((EvasiveAIControl)Controller).speed + playerRigidbody.velocity.magnitude);

        GameObject.FindGameObjectWithTag("Waypoint").transform.position = player.position + playerRigidbody.velocity * lookAheadTime;
        Flee(player.position + playerRigidbody.velocity * lookAheadTime);
    }

    public override int CheckTransition()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
            return (int)EvasiveAIControl.States.FLEE;

        return ID;
    }

    private void Flee(Vector3 pursuer)
    {
        Vector3 desiredVelocity = (position.position - pursuer).normalized
            * ((EvasiveAIControl)Controller).speed;

        rigidbody.velocity = (desiredVelocity - rigidbody.velocity) / rigidbody.mass * Time.deltaTime
            + rigidbody.velocity;
    }
}
