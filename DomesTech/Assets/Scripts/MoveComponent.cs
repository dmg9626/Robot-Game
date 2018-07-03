using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : MonoBehaviour {
	/// <summary>
	/// Movement speed
	/// </summary>
	public float moveSpeed;

	/// <summary>
	/// Animator
	/// </summary>
	Animator animator;

	/// <summary>
	/// Direction player is currently facing
	/// </summary>
	public BaseConstants.Direction currentDirection;

	void Start()
	{
		animator = GetComponent<Animator>();
	}

    /// <summary>
    /// Moves/animates actor based on provided horizontal/vertical input from MoveCommand
    /// </summary>
    /// <param name="input">Player input</param>
    public void ManageMovement(Vector2 input) 
    {
        // Move actor in direction of input
        Vector2 movement = input * moveSpeed;
        gameObject.GetComponent<Rigidbody2D>().velocity = movement;

		// Animate walking if receiving input
        if (input.x != 0f || input.y != 0f) {
            animator.SetBool("Moving", true); 
            AnimateWalk(input);
        } 
        else {
            animator.SetBool("Moving", false);
        }
    }

    /// <summary>
    /// Animates movement based on horizontal/vertical input
    /// </summary>
    /// <param name="input">Player input</param>
    private void AnimateWalk(Vector2 input) 
    {
		// Get current direction
        currentDirection = (BaseConstants.Direction)animator.GetInteger("Direction");

        // Calculate and set new direction
        BaseConstants.Direction newDirection = FaceDirection(input);
        animator.SetInteger("Direction", (int)newDirection);

        if (currentDirection != newDirection) {
            GameController.LogCommands.Log("Facing direction: " + newDirection);
        }
    }

	/// <summary>
	/// Calculates direction for player to face based on horizontal/vertical input
	/// </summary>
	/// <param name="horizontal">Horizontal input</param>
	/// <param name="vertical">Vertical input</param>
	/// <returns>Direction to face</returns>
	private BaseConstants.Direction FaceDirection(Vector2 input)
	{
		// Check if moving diagonally
		if(input.x != 0 && input.y != 0){
			if(DirectionHelper.IsVertical(currentDirection)) {
                return ParseInput(input.y, false);
            }
			else {
                return ParseInput(input.x, true);
            }
		}

		// Otherwise face in direction of raw input
		else if(input.x != 0) {
            return ParseInput(input.x, true);
		}
		else if(input.y != 0) {
            return ParseInput(input.y, false);
		}

		return currentDirection;
	}

    /// <summary>
    /// Parses a float representing player input (horizontal or vertical) and returns corresponding direction
    /// </summary>
    /// <param name="input">Player input on horizontal/vertical axis</param>
    /// <param name="horizontal">True if input is horizontal, false if vertical</param>
    private BaseConstants.Direction ParseInput(float input, bool horizontal)
    {
        if (input > 0) {
            return horizontal ? BaseConstants.Direction.Right : BaseConstants.Direction.Up;
        }
        else {
            return horizontal ? BaseConstants.Direction.Left : BaseConstants.Direction.Down;
        }
    }
}
