using UnityEngine;
using System.Collections;

/// <summary>
/// Base class for states. In order to use the state machine system a state must derive itself from this class.
/// It contains all the methods required for a state machine to function - Enter, Exit, Update, and CheckTransition.
/// 
/// Omitting CheckTransition, states should be designed in a modular way; they should be written as though no
/// knowledge of other states exist. As such, any helper methods that only benefit a state should be kept in the
/// class that inherits this class.
/// </summary>
public abstract class AbstractState {
    // ID that identifies the state in a state machine.
    private int id;
    public int ID { get { return id; } }

    /* Reference to the controller that instantiated and controls this state.
     * A reference is given to each state so that they all have access to global data for the object
     * this control is attached to. While a cast is required to access implementation-specific details,
     * this insures that all states will still get a reference to the controller in some capacity.
     */
    private AbstractControl controller;
    public AbstractControl Controller { get { return controller; } }

    public AbstractState(int id, AbstractControl controller)
    {
        this.id = id;
        this.controller = controller;
    }

    /// <summary>
    /// Called each time a state becomes the current state. Any initialization logic required
    /// at the start of a state should go here.
    /// </summary>
    public abstract void Enter();

    /// <summary>
    /// Called when a state is about to lose focus. Release any data that will be re-initialized
    /// if/when this state regains focus. Also, if the controller is doing anything specific to this
    /// state (for example, a MonoBehaviour exclusive thing like coroutines) signal it to stop that.
    /// </summary>
    public abstract void Exit();
	
	/// <summary>
	/// Called by the state machine. Update logic to create the behaviour
    /// behind this state goes here.
	/// </summary>
    public abstract void Update();

    /// <summary>
    /// This is where it is determined if a transition is required. Perform any calculations
    /// required, or access global control information to determine transition eligibility.
    /// </summary>
    /// <returns>ID representation of the state to transition to.</returns>
    public abstract int CheckTransition();
}
