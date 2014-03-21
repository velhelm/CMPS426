using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SeekControl : AbstractControl {

    public enum States
    {
        DEFAULT,
        SEEK,
        PURSUIT
    }

    public override StateMachine CreateMachine()
    {
        AbstractState idle = new IdleState((int)States.DEFAULT, this);
        AbstractState seek = new SeekState((int)States.SEEK, this);
        AbstractState pursuit = new PursuitState((int)States.PURSUIT, this);

        SeekStateMachine stateMachine = new SeekStateMachine();
        stateMachine.AddDefaultState(idle);
        stateMachine.AddState(seek);
        stateMachine.AddState(pursuit);

        return stateMachine;
    }
}
