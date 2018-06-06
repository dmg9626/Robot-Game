using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : Actor 
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

        // TODO: do this more gracefully, allow tweaking in GUI
        commands = new List<Command> { shootCommand, moveCommand };

        // Commands control player (this gameObject)
        actor = GetComponent<Actor>();
    }

    void Update () 
    {
        // Iterate through each commandType in action list
        foreach(Command.Type commandType in actionList) {

            // Execute each corresponding command
            foreach(Command command in commands.FindAll(i => i.type == commandType)) {
                command.execute(actor);
            }
        }
        //moveCommand.execute(actor);
        //shootCommand.execute(gameObject);
    }
}