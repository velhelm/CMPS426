using UnityEngine;
using System.Collections;

/// <summary>
/// All FSM controls inherit this class. Controls should provide themselves with an enumeration
/// representing all of their states. Controls will use the MonoBehaviour methods to trigger the
/// methods of their machine.
/// </summary>
public abstract class AbstractControl : MonoBehaviour {
    
    /// <summary>
    /// Depending on the type of GameObject, there might be updates required regardless of state.
    /// In this case, GlobalUpdate should be called to handle such update logic. This is also where
    /// transition-pertinent logic can be calculated.
    /// </summary>
    public virtual void GlobalUpdate() { }
}
