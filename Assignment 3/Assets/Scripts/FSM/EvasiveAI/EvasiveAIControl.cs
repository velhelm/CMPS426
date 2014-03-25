using UnityEngine;
using System.Collections;

public class EvasiveAIControl : AbstractControl {
    public float speed;

    public enum States
    {
        EVADE,
        FLEE
    }

    public override StateMachine CreateMachine()
    {
        StateMachine machine = new StateMachine();
        machine.AddDefaultState(new EvadeState((int)States.EVADE, this));
        machine.AddState(new FleeState((int)States.FLEE, this));

        return machine;
    }

    public override void GlobalUpdate()
    {
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
    }

    public Transform GetPlayerTransform()
    {
        return GameObject.FindGameObjectWithTag("Player").transform;
    }

    public Rigidbody GetPlayerRigidbody()
    {
        return GameObject.FindGameObjectWithTag("Player").rigidbody;
    }
}
