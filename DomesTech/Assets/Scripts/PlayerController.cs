using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : Actor 
{
    /// <summary>
    /// Actor player is currently controlling
    /// </summary>
    public GameObject actor;

    
    protected Command shootCommand;
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
        foreach(Command.Type commandType in actionQueue)
        {
            commands.Find(i => i.type == commandType).execute(gameObject);
        }
        //moveCommand.execute(actor);
        //shootCommand.execute(gameObject);
    }
}