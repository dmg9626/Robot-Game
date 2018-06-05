using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : Command {
	public MoveCommand() { type = Type.MOVEMENT; }

	public override void execute(GameObject actor) {

		// Get player input
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        // Move/animate player
        actor.GetComponent<MoveComponent>().ManageMovement(horizontal, vertical);
	}
}
