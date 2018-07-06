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

<<<<<<< HEAD
        // Commands control player (this gameObject)
        actor = GetComponent<Actor>();
=======
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
>>>>>>> de865690d1b48536b2cad6743fcb78a6c4662192
    }

    void Update () 
    {
<<<<<<< HEAD
        // Iterate through each commandType in action list
        foreach(Command.Type commandType in actionList) {

            // Execute each corresponding command
            foreach(Command command in commands.FindAll(i => i.type == commandType)) {
                command.execute(actor);
            }
=======
        // Iterate through each commandType in action queue and execute corresponding command
        foreach(Command.Type commandType in actor.actionQueue)
        {
            commands.Find(i => i.type == commandType).execute(actor);
>>>>>>> de865690d1b48536b2cad6743fcb78a6c4662192
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