using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// All state machines are derived from this class. It contains methods for updating the states it is
/// responsible for, as well as making transitions whenever they are necessary. The machine uses a Dictionary
/// to keep track of states.
/// </summary>
public class StateMachine {
    // Private dictionary of states.
    protected Dictionary<int, AbstractState> states;
    // Reference to current state.
    protected AbstractState currentState;
    // ID of default state. Obviously.
    private int defaultStateId;

    public StateMachine() 
    {
        states = new Dictionary<int, AbstractState>();
    }

    /// <summary>
    /// Sets the given state as the default & current state. When creating a state machine the
    /// initial state should be added with this method.
    /// </summary>
    /// <param name="state">Default state.</param>
    public virtual void AddDefaultState(AbstractState state)
    {
        // Add the passed state into the Dictionary.
        AddState(state);

        // Set the state as the default state to transition to upon call to Reset.
        defaultStateId = state.ID;

        // Set this state as the current state.
        Transition(state.ID);
    }

    /// <summary>
    /// Adds the given state to the machine.
    /// </summary>
    /// <param name="state">State being added to the machine.</param>
    public virtual void AddState(AbstractState state)
    {
        states.Add(state.ID, state);
    }
	
	/// <summary>
	/// State machine update method, called by the controller. By default it updates the current state,
    /// checks if a transition is required and performs the transition if that's the case. 
    /// While this method is virtual, it should never require direct implementation unless 
    /// you're adding more responsiblity to the machine.
	/// </summary>
	public virtual void Update () {
	    // Update current state.
        currentState.Update();

        // Check for transition.
        int newId = currentState.CheckTransition();

        // Make transition if required.
        if (currentState.ID != newId)
        {
            Transition(newId);
        }
	}

    public virtual void FixedUpdate()
    {
        currentState.FixedUpdate();
    }

    /// <summary>
    /// Transitions from one state to another. Should only ever be called
    /// from the state machine's update function.
    /// </summary>
    /// <param name="id">ID mapped to the state in the Dictionary.</param>
    protected void Transition(int id)
    {
        // Call current state's Exit method. Base case: Initial transition.
        if (currentState != null) currentState.Exit();
        // Set current state to state mapped to the given key.
        currentState = states[id];
        // Call the new current state's Enter method.
        currentState.Enter();
    }

    /// <summary>
    /// Resets the state machine by transitioning to the default state.
    /// </summary>
    public virtual void Reset()
    {
        Transition(defaultStateId);
    }
}
