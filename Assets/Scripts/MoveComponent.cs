using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : MonoBehaviour {
	public float moveSpeed;
	Animator animator;

	/// <summary>
	/// Direction player is currently facing
	/// </summary>
	BaseConstants.Direction currentDirection;

	void Start()
	{
		animator = gameObject.GetComponent<Animator>();
	}

	public void ManageMovement(float horizontal,float vertical) 
    {
        
        Vector2 movement = new Vector2 (horizontal * moveSpeed, vertical * moveSpeed);
        gameObject.GetComponent<Rigidbody2D>().velocity = movement;

        if (horizontal != 0f || vertical != 0f) {
            animator.SetBool("Moving", true); 
            animateWalk(horizontal, vertical);
        } 
        else {
            animator.SetBool("Moving", false);
        }
    }

    void animateWalk(float horizontal,float vertical) 
    {
		// Get current direction
        currentDirection = (BaseConstants.Direction)animator.GetInteger("Direction");

		// Calculate and set new direction
		int newDirection = (int)CalculateDirection(horizontal, vertical);
		animator.SetInteger("Direction", newDirection);
    }

	BaseConstants.Direction CalculateDirection(float horizontal, float vertical)
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

		Debug.Log(horizontal + "," + vertical);

		return direction;
	}

	bool IsVertical(BaseConstants.Direction direction){
		return (direction == BaseConstants.Direction.Up || direction == BaseConstants.Direction.Down);
	}
}
