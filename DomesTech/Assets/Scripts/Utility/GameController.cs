using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	[Header("Loggers")]
	public bool logPhysics;
    
    public bool logCommand;

	void Start()
	{
        // Initialize loggers
		LogPhysics = new LogHelper();
        LogCommands = new LogHelper();
        InitializeLoggers();

        // Player Controller
        PlayerController = GetComponent<PlayerController>();
	}

	private void InitializeLoggers()
	{
		LogPhysics.SetLogging(logPhysics);
        LogCommands.SetLogging(logCommand);
	}
	/// <summary>
	/// Physics logger
	/// </summary>
	public static LogHelper LogPhysics;

    /// <summary>
    /// Command logger
    // Ideally this should allow filtering by Command and Actor executing it
    /// </summary>
    public static LogHelper LogCommands;

    /// <summary>
    /// Gets the player controller.
    /// </summary>
    /// <value>
    /// The player controller.
    /// </value>
    public static PlayerController PlayerController { get; private set; }

}
