using UnityEngine;
using System.Collections;

/// <summary>
/// All FSM controls inherit this class. Controls should provide themselves with an enumeration
/// representing all of their states. Controls will use the MonoBehaviour methods to trigger the
/// methods of their machine.
/// </summary>
public abstract class AbstractControl : MonoBehaviour {
    private AbstractStateMachine stateMachine;

    /// <summary>
    /// By default the control updates the state machine on each update. This ensures
    /// that the client conforms to the contract of using a state machine in this system.
    /// </summary>
    void Update()
    {
        if (stateMachine == null)
            throw new System.ArgumentException("State machine cannot be null", "original");

        stateMachine.Update();
    }

    /// <summary>
    /// Depending on the type of GameObject, there might be updates required regardless of state.
    /// In this case, GlobalUpdate should be called to handle such update logic. This is also where
    /// transition-pertinent logic can be calculated.
    /// 
    /// This method
    /// </summary>
    public virtual void GlobalUpdate() { } 
}
