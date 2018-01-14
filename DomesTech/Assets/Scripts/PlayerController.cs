using UnityEngine;
using System.Collections;

public class PlayerController : Actor 
{
    /// <summary>
    /// Actor player is currently controlling
    /// </summary>
    public GameObject actor;

    void Update () 
    {
        // Get commands
        Command shootCommand = new PrimaryShootCommand();
        Command moveCommand = new MoveCommand();

        // Execute commands
        if(Input.GetKeyDown(KeyCode.Space)) {
            shootCommand.execute(gameObject);
        }

        moveCommand.execute(actor);
    }
}