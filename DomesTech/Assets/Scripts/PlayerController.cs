using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

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

    void Start()
    {
        // Get commands
        shootCommand = new ShootCommand();
        moveCommand = new MoveCommand();

        // TODO: do this more gracefully, allow tweaking in GUI
        commands = new List<Command> { shootCommand, moveCommand };

        // Set actor to player if null
        if(actor == null)
        {
            SetActor(FindPlayer());
        }
    }

    /// <summary>
    /// Returns reference to Player actor in scene (assumes isPlayer = true)
    /// </summary>
    public Actor FindPlayer()
    {
        return GameObject.FindObjectsOfType<Actor>().Where(i => i.isPlayer).First() as Actor;
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

    /// <summary>
    /// Sets the actor controlled by player input
    /// </summary>
    /// <param name="actor">Actor</param>
    public void SetActor(Actor actor)
    {
        this.actor = actor;
        Debug.Log("Changed actor to " + actor.name);
    }
}