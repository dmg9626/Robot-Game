using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command : MonoBehaviour {

	public Command() {}

    public enum Type
    {
        MOVEMENT,
        ATTACK
    }

    /// <summary>
    /// Command type
    /// </summary>
    public Type type;

    /// <summary>
    /// Executes the command on the provided actor.
    /// </summary>
    /// <param name="actor">The actor.</param>
    public virtual void execute(GameObject actor) {}
}
