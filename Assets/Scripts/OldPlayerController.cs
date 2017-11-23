using UnityEngine;
using System.Collections;

public class OldPlayerController : MonoBehaviour 
{
    public enum Direction {
        Up = 1,
        Right,
        Down,
        Left
    }

    private Animator animator;
    private Direction currentDirection;
    public float moveSpeed;

    void Start () 
    { 
        animator = gameObject.GetComponent<Animator>();
    }

    void Update () 
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        ManageMovement(h, v);
    }

    void ManageMovement(float horizontal,float vertical) 
    {
        if (horizontal != 0f || vertical != 0f) 
        {
            animator.SetBool("Moving", true); 
            animateWalk(horizontal, vertical);
        } 
        else 
        {
            animator.SetBool("Moving", false);
        }

        Vector3 movement = new Vector3 (horizontal * moveSpeed, vertical * moveSpeed, 0);
        gameObject.GetComponent<Rigidbody2D>().velocity = movement;
    }

    void animateWalk(float horizontal,float vertical) 
    {
        currentDirection = (Direction)animator.GetInteger("Direction");

        if ((vertical > 0) && (vertical > horizontal)) {
            animator.SetInteger("Direction", (int)Direction.Up); // up
        }
        else if ((horizontal > 0) && (vertical < horizontal)) {
            animator.SetInteger("Direction", (int)Direction.Right); // right
        }
        else if ((vertical < 0) && (vertical < horizontal)) {
            animator.SetInteger("Direction", (int)Direction.Down); // down
        }
        else if ((horizontal < 0 ) && (vertical > horizontal)) {
            animator.SetInteger("Direction", (int)Direction.Left); // left
        }
    
    }
}