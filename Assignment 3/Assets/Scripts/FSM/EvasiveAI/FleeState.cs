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

    public override int CheckTransition() { return ID; }
}
