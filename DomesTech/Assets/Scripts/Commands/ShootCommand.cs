using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCommand : Command {

	public ShootCommand() {
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

    /// <summary>
    /// Checks actor's inventory for projectile, then shoots it from actor's position
    /// </summary>
    /// <param name="actor">Actor</param>
    private void Shoot(Actor actor)
    {
        GameController.LogCommands.Log("Executing ShootCommand on " + actor.name);

        // Instantiate bullet (TODO: maybe make this less gross)
        projectile = GameObject.Instantiate(actor.inventory.Find(i => i.GetComponent<Projectile>())).GetComponent<Projectile>();
        if(projectile != null)
        {
            // Set bullet on player
            projectile.transform.position = actor.transform.position;

            // Get direction actor is facing (TODO: consider handling this for actors that don't rotate or don't have an Animator)
            BaseConstants.Direction direction = actor.GetComponent<MoveComponent>().currentDirection;
            GameController.LogCommands.Log("Projectile direction: " + direction.ToString());

            // Send projectile in that direction
            Vector2 trajectory = DirectionHelper.DirectionToVector(direction);
            projectile.Shoot(trajectory, actor);
        }
        else
        {
            GameController.LogCommands.LogWarning("Primary Shoot Command: could not find projectile in actor " + actor.name + "'s inventory");
        }
    }
}
