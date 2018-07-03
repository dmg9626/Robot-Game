using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Command 
{
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
    public virtual void execute(Actor actor) {}
}
