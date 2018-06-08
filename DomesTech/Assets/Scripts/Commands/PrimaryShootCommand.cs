using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryShootCommand : Command {

	public PrimaryShootCommand() {
        type = Type.ATTACK;
    }

    /// <summary>
    /// Bullet to be shot
    /// </summary>
    public Projectile projectile;

    /// <summary>
    /// Executes Weapon's PrimaryAttack() method
    /// <param name="actor">Actor to execute command on</param>
    /// </summary>
    public override void execute(Actor actor) {

        if(Input.GetButtonDown("Shoot"))
        {
            Shoot(actor);
        }
		
	}

    private void Shoot(Actor actor)
    {
        Debug.Log("Executing ShootCommand on " + actor.name);

        // Get direction actor is facing (TODO: consider handling this for actors that don't rotate or don't have an Animator)
        BaseConstants.Direction direction = (BaseConstants.Direction)actor.GetComponent<Animator>().GetInteger("Direction");
        Debug.Log("Bullet direction: " + direction.ToString());

        // Instantiate bullet (TODO: maybe make this less gross)
        projectile = GameObject.Instantiate(actor.inventory.Find(i => i.GetComponent<Projectile>())).GetComponent<Projectile>();
        if(projectile != null)
        {
            // Set bullet on player
            projectile.transform.position = actor.transform.position;

            SetProjectileTrajectory(projectile, direction);
        }
        else
        {
            GameController.LogCommands.LogWarning("Primary Shoot Command (" + actor.name + "): could not find projectile on actor");
        }

        
    }

    /// <summary>
    /// Sets trajectory of projectile
    /// <param name="projectile">Projectile to set trajectory of</param>
    /// <param name="direction">Direction to send bullet</param>
    /// </summary>

    private void SetProjectileTrajectory(Projectile projectile, BaseConstants.Direction direction)
	{
		// Start with base trajectory (0,0)
		Vector2 trajectory = new Vector2(0,0);

        switch(direction)
        {
            case BaseConstants.Direction.Up:
                trajectory.y = 1;
                break;
            case BaseConstants.Direction.Down:
                trajectory.y = -1;
                break;
            case BaseConstants.Direction.Left:
                trajectory.x = -1;
                break;
            case BaseConstants.Direction.Right:
                trajectory.x = 1;
                break;
        }

		// Set trajectory
		projectile.SetTrajectory(trajectory);
	}
}
