using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// Actor player is currently controlling
    /// </summary>
    public Actor actor;

    /// <summary>
    /// Shoots a projectile in direction player is facing
    /// </summary>
    protected Command shootCommand;

    /// <summary>
    /// Moves/animates player
    /// </summary>
    protected Command moveCommand;

    /// <summary>
    /// Collection of commands to execute
    /// </summary>
    protected List<Command> commands;

    void Start() {
        // Get commands
        shootCommand = new PrimaryShootCommand();
        moveCommand = new MoveCommand();

        // TODO: do this more gracefully
        commands = new List<Command> { shootCommand, moveCommand };
    }

    void Update () 
    {
        // Iterate through each commandType in action queue and execute corresponding command
        foreach(Command.Type commandType in actor.actionQueue)
        {
            commands.Find(i => i.type == commandType).execute(actor);
        }
        //moveCommand.execute(actor);
        //shootCommand.execute(gameObject);
    }
}