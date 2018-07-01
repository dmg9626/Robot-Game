using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour {
	/// <summary>
	/// Actor health
	/// </summary>
	public int health;
	
	/// <summary>
	/// True if actor is player character
	/// </summary>
	public bool isPlayer;

    /// <summary>
    /// Contains objects that are used by the actor
    /// </summary>
    public List<GameObject> inventory;

    /// <summary>
    /// Represents order in which player actions will occur
    /// </summary>
    public List<Command.Type> actionQueue;

    /// <summary>
    /// Called on left mouse click
    /// </summary>
    void OnMouseDown()
    {
        // Assign this actor to PlayerController
        GameController.PlayerController.SetActor(this);
    }
}
