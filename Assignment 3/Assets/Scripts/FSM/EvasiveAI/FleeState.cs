using UnityEngine;
using System.Collections;

public class FleeState : AbstractState {
    Transform player, position;
    Rigidbody rigidbody;

    public FleeState(int id, AbstractControl control)
        : base(id, control) { }

    public override void Enter()
    {
        player = ((EvasiveAIControl)Controller).GetPlayerTransform();
        position = Controller.transform;
        rigidbody = Controller.rigidbody;

        GameObject.FindGameObjectWithTag("StateHeader").GetComponent<GUIText>().text = "Flee State";
    }

    public override void Exit()
    {
        player = null;
        position = null;
        rigidbody = null;
    }

    public override void Update() { }

    public override void FixedUpdate()
    {
        Vector3 desiredVelocity = (position.position - player.position).normalized
            * ((EvasiveAIControl)Controller).speed;

        rigidbody.velocity = (desiredVelocity - rigidbody.velocity) / rigidbody.mass * Time.deltaTime
            + rigidbody.velocity;
    }

    public override int CheckTransition() 
    { 
        if (Input.GetKeyDown(KeyCode.Alpha1))
            return (int) EvasiveAIControl.States.EVADE;

        return ID; 
    }
}
