using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command {

	public Command() {}

    public enum Type
    {
        MOVEMENT,
        ATTACK
    }

    /// <summary>
    /// Type - used to group similar commands (ex. MOVEMENT = jumping/walking commands, ATTACK = melee/projectile attack commands)
    /// </summary>
    public Type type;

    /// <summary>
    /// Executes the command on the provided actor.
    /// </summary>
    /// <param name="actor">The actor.</param>
    public virtual void execute(Actor actor) {}
}
