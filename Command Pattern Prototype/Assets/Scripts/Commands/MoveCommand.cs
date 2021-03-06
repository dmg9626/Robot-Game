﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

This command gets directional input and moves/animates the actor accordingly. It requires the actor to
have a MoveComponent and an Animator/AnimationController configured for movement.

At the moment it only works for player input - some reworking is necessary for this command to be used for
handling movement of NPCs (TODO: work out a solution that makes use of NavMesh Agent pathing system, ideally 
on a separate NPCMoveComponent)

 */

public class MoveCommand : Command {

	public override void execute(Actor actor) {

		// Get player input
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        MoveComponent moveComponent = actor.GetComponent<MoveComponent>();

        // Check for attached MoveComponent
        if(moveComponent != null)
        {
            // Move/animate player
            moveComponent.ManageMovement(input);
        }
        else
        {
            GameController.LogWarning("Unable to execute MoveCommand on actor " + actor.name + " - no MoveComponent found", GameController.LogCommands);
        }
        
	}
}
