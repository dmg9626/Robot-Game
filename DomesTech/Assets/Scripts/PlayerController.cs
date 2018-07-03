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

    /*
     * The focus of this redesign is to move commands entirely from the PlayerController to the Actor
     * That way different actors can have different sets of commands
     * Switching between actors should occur smoothly with no side effects
     */

    void Start()
    {
        // Get commands
        //shootCommand = new ShootCommand();
        //moveCommand = new MoveCommand();

        // TODO: do this more gracefully
        //commands = new List<Command> { new ShootCommand(), new MoveCommand() };

        // Set actor to player if null
        if(actor == null) {
            SetActor(FindPlayer());
        }

        // Initialize commands
        //actor.commands = new List<Command> { new ShootCommand(), new MoveCommand() };
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
        foreach(Command.Type commandType in actor.actionQueue) {
            actor.commands.Find(i => i.type == commandType).execute(actor);
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