using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour {
	/// <summary>
	/// Actor health
	/// </summary>
	public float health;
	
	/// <summary>
	/// True if actor is player character
	/// </summary>
	public bool isPlayer;

    /// <summary>
    /// Contains objects that are used by the actor
    /// </summary>
    public List<GameObject> inventory;

    
    // TODO: use a dictionary to relate commands and actionQueue

    /// <summary>
    /// Represents available commands and order in which they execute
    /// </summary>
    public List<Command.Type> actionQueue;

    /// <summary>
    /// Collection of commands to execute
    /// </summary>
    public List<Command> commands;

    /// <summary>
    /// Text label displayed below actor
    /// </summary>
    protected TextMesh textMesh;

    /// <summary>
    /// Called on left mouse click
    /// </summary>
    void OnMouseDown()
    {
        // Assign this actor to PlayerController
        GameController.PlayerController.SetActor(this);
    }

    private void Start()
    {
        // Initialize text label below actor
        textMesh = transform.GetComponentInChildren<TextMesh>();
        UpdateLabel();

        // Initialize each command in commands list
        InitializeCommands();
    }

    private void InitializeCommands()
    {
        for(int i = 0; i < commands.Count; i++) {
            GameController.LogCommands.Log(name + " | Initializing command: " + commands[i]);
            switch(commands[i].type) {
                case Command.Type.ATTACK:
                    commands[i] = new ShootCommand();
                    break;
                case Command.Type.MOVEMENT:
                    commands[i] = new MoveCommand();
                    break;
            }

            GameController.LogCommands.Log(name + " | Initialized " + commands[i].type + " command");
        }
    }

    private void Update()
    {
        // Disable self when health reaches 0
        if(health <= 0) {
            Debug.Log(name + " died");
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit by " + collision.gameObject.name);

        // Check for projectile
        Projectile projectile = collision.gameObject.GetComponent<Projectile>();
        if(projectile != null) {
            Debug.Log("Projectile: " + projectile.name);

            // Decrement health if projectile shot by different actor
            if(projectile.actor != this) {
                health -= projectile.damage;

                GameObject.Destroy(projectile.gameObject);
                Debug.Log("Health: " + health);

                // Update label with reduced health
                UpdateLabel();
            }
        }
    }

    /// <summary>
    /// Updates text label below actor
    /// </summary>
    public void UpdateLabel()
    {
        textMesh.text = name + "\nHealth: " + health;
    }
}
