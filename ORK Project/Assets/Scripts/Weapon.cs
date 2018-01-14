using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
	/// <summary>
	/// Weapon ID
	/// </summary>
	public int id;

	/// <summary>
	/// Damage of primary attack
	/// </summary>
	public int primaryDamage;

	/// <summary>
	/// Damage of secondary attack
	/// </summary>
	public int secondaryDamage;

	/// <summary>
	/// Delay between attacks
	/// </summary>
	protected float _weaponDelay;

	/// <summary>
	/// Use weapon's primary attack
	/// </summary>
	public virtual void PrimaryAttack() {}

	/// <summary>
	/// Use weapon's secondary attack
	/// </summary>
	public virtual void SecondaryAttack() {}
	
	
	
	
}
