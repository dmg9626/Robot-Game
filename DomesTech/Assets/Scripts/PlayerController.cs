using UnityEngine;
using System.Collections;

public class PlayerController : Actor 
{
    public GameObject actor;

    void Update () 
    {
        // Get commands
        Command commandSpace = new PrimaryShootCommand();

        // Execute commands
        if(Input.GetKeyDown(KeyCode.Space)) {
            commandSpace.execute(gameObject);
        }
    }

    
}