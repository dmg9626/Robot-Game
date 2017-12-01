using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : Command {
	public MoveCommand() {}

	public enum Direction {
        Up = 1,
        Right,
        Down,
        Left
    }

    private Animator animator;
    private Direction currentDirection;
    public float moveSpeed;

	public override void execute(GameObject actor) {
		// Get reference to animator
		animator = actor.GetComponent<Animator>();

		// Get horizontal/vertical input
		float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
	}
}
