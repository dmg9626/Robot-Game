using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour {
	/// <summary>
	/// Actor health
	/// </summary>
	public int health;

	/// <summary>
	/// Actor movement speed
	/// </summary>
	public int speed;
	
	/// <summary>
	/// True if actor is player character
	/// </summary>
	public bool isPlayer;

    /// <summary>
    /// Contains objects that are used by the actor
    /// </summary>
    public List<GameObject> inventory;

    /// <summary>
    /// List of commands available to the actor
    /// </summary>
    protected List<Command.Type> actionList = new List<Command.Type>() {
		Command.Type.MOVEMENT,
		Command.Type.ATTACK
	};
}
