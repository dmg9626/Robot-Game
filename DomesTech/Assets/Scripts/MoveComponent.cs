using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : MonoBehaviour {
	/// <summary>
	/// Movement speed
	/// </summary>
	private float moveSpeed;

	/// <summary>
	/// Animator
	/// </summary>
	Animator animator;

	/// <summary>
	/// Direction player is currently facing
	/// </summary>
	BaseConstants.Direction currentDirection;

	void Start()
	{
		animator = gameObject.GetComponent<Animator>();
		moveSpeed = GetComponent<Actor>().speed;
	}

	/// <summary>
	/// Moves/animates actor based on provided horizontal/vertical input from MoveCommand
	/// </summary>
	/// <param name="horizontal">Horizontal input</param>
	/// <param name="vertical">Vertical input</param>
	public void ManageMovement(float horizontal,float vertical) 
    {
        // Move actor in direction of input
        Vector2 movement = new Vector2 (horizontal * moveSpeed, vertical * moveSpeed);
        gameObject.GetComponent<Rigidbody2D>().velocity = movement;

		// Animate walking if receiving input
        if (horizontal != 0f || vertical != 0f) {
            animator.SetBool("Moving", true); 
            AnimateWalk(horizontal, vertical);
        } 
        else {
            animator.SetBool("Moving", false);
        }
    }

	/// <summary>
	/// Animates movement based on horizontal/vertical input
	/// </summary>
	/// <param name="horizontal">Horizontal input</param>
	/// <param name="vertical">Vertical input</param>
    private void AnimateWalk(float horizontal,float vertical) 
    {
		// Get current direction
        currentDirection = (BaseConstants.Direction)animator.GetInteger("Direction");

		// Calculate and set new direction
		int newDirection = (int)CalculateDirection(horizontal, vertical);
		animator.SetInteger("Direction", newDirection);
    }

	/// <summary>
	/// Calculates direction for player to face based on horizontal/vertical input
	/// </summary>
	/// <param name="horizontal">Horizontal input</param>
	/// <param name="vertical">Vertical input</param>
	/// <returns>Direction to face</returns>
	private BaseConstants.Direction CalculateDirection(float horizontal, float vertical)
	{
		BaseConstants.Direction direction = currentDirection;

		// Check if moving diagonally
		if(horizontal != 0 && vertical != 0){
			if(IsVertical(currentDirection)) {
				if(vertical > 0) {
					direction = BaseConstants.Direction.Up;
				}
				else {
					direction = BaseConstants.Direction.Down;
				}
			}
			else {
				if(horizontal > 0) {
					direction = BaseConstants.Direction.Right;
				}
				else {
					direction = BaseConstants.Direction.Left;
				}
			}
		}

		// Otherwise face in direction of raw input
		else if(horizontal != 0) {
			if(horizontal > 0) {
				direction = BaseConstants.Direction.Right;
			}
			else {
				direction = BaseConstants.Direction.Left;
			}
		}
		else if(vertical != 0) {
			if(vertical > 0) {
				direction = BaseConstants.Direction.Up;
			}
			else {
				direction = BaseConstants.Direction.Down;
			}
		}

        if(currentDirection != direction) {
            GameController.LogCommands.Log("Facing direction: " + direction);
        }

		return direction;
	}

	/// <summary>
	/// Returns true if direction is vertical
	/// </summary>
	/// <param name="direction">Direction</param>
	private bool IsVertical(BaseConstants.Direction direction){
		return (direction == BaseConstants.Direction.Up || direction == BaseConstants.Direction.Down);
	}
}
