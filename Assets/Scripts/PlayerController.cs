using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
    public enum Direction {
        Up = 1,
        Right,
        Down,
        Left
    }
    private Animator animator;
    public GameObject actor;
    public float moveSpeed;
    void Start () 
    {
        animator = gameObject.GetComponent<Animator>();
        actor = gameObject;
        // BoxCollider2D collider = gameObject.GetComponent<BoxCollider2D>();
        // collider.size = new Vector2(colliderSize, colliderSize);
    }

    void Update () 
    {
        // Get player input
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        // Move/animate player
        ManageMovement(horizontal, vertical);

        // Get commands
        Command commandSpace = new ShootCommand();

        // Execute commands
        if(Input.GetKeyDown(KeyCode.Space)) {
            commandSpace.execute(gameObject);
        }
    }

    void ManageMovement(float horizontal,float vertical) 
    {
        
        Vector3 movement = new Vector3 (horizontal * moveSpeed, vertical * moveSpeed, 0);
        gameObject.GetComponent<Rigidbody2D>().velocity = movement;

        if (horizontal != 0f || vertical != 0f) 
        {
            animator.SetBool("Moving", true); 
            animateWalk(horizontal, vertical);
        } 
        else 
        {
            animator.SetBool("Moving", false);
        }
    }

    void animateWalk(float horizontal,float vertical) 
    {
        //currentDirection = (Direction)animator.GetInteger("Direction");

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