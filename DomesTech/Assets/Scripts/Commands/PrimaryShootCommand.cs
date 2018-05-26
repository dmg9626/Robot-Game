using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryShootCommand : Command {

	public PrimaryShootCommand() { type = Type.ATTACK; }

    /// <summary>
    /// Bullet to be shot
    /// </summary>
    public GameObject bullet;

    /// <summary>
    /// Executes Weapon's PrimaryAttack() method
    /// <param name="actor">Actor to execute command on</param>
    /// </summary>
    public override void execute(GameObject actor) {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot(actor);
        }
		
	}

    private void Shoot(GameObject actor)
    {
        Debug.Log("Executing ShootCommand on " + actor.name);

        // Parse actor direction
        BaseConstants.Direction direction = (BaseConstants.Direction)actor.GetComponent<Animator>().GetInteger("Direction");
        Debug.Log("Bullet direction: " + direction.ToString());

        // Instantiate bullet
        bullet = GameObject.Instantiate(Resources.Load("Bullet")) as GameObject;

        // Set bullet on player
        bullet.transform.position = actor.transform.position;

        SetProjectileTrajectory(bullet, direction);
    }

    /// <summary>
    /// Sets trajectory of projectile
    /// <param name="projectile">Projectile to set trajectory of</param>
    /// <param name="direction">Direction to send bullet</param>
    /// </summary>

    private void SetProjectileTrajectory(GameObject projectile, BaseConstants.Direction direction)
	{
		// Start with base trajectory (0,0)
		Vector2 trajectory = new Vector2(0,0);

		// Calculate trajectory by direction
		if(direction.Equals(BaseConstants.Direction.Up)) {
			trajectory.y = 1;
		}
		else if(direction.Equals(BaseConstants.Direction.Right)) {
			trajectory.x = 1;
		}
		else if(direction.Equals(BaseConstants.Direction.Down)) {
			trajectory.y = -1;
		}
		else if(direction.Equals(BaseConstants.Direction.Left)) {
			trajectory.x = -1;
		}

		

		// Set trajectory (hard-coded to right)
		projectile.GetComponent<Projectile>().SetTrajectory(trajectory);
	}
}
