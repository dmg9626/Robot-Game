using UnityEngine;
using System.Collections;

public class PlayerController : Actor 
{
    public GameObject actor;

    // Use this for initialization
	void Start () 
	{
        actor = gameObject;
	}


    void Update () 
    {
        // Get player input
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        // Move/animate player
        GetComponent<MoveComponent>().ManageMovement(horizontal, vertical);

        // Get commands
        Command commandSpace = new PrimaryShootCommand();

        // Execute commands
        if(Input.GetKeyDown(KeyCode.Space)) {
            commandSpace.execute(gameObject);
        }
    }

    
}