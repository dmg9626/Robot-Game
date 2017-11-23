using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCommand : Command {
	public enum Direction {
        Up = 1,
        Right,
        Down,
        Left
    }

	GameObject bullet;
	public ShootCommand() {}
	
	public override void execute(GameObject actor) {
		Debug.Log("Executing ShootCommand on " + actor.name);

		// Parse actor direction
		Direction direction = (Direction)actor.GetComponent<Animator>().GetInteger("Direction");
		Debug.Log("Bullet direction: " + direction.ToString());

		// Instantiate bullet
		bullet = GameObject.Instantiate(Resources.Load("Bullet")) as GameObject;

		// Set bullet on player
		bullet.transform.position = actor.transform.position;

		SetProjectileTrajectory(bullet, direction);
	}

	private void SetProjectileTrajectory(GameObject bullet, Direction direction)
	{
		Vector2 trajectory = new Vector2(0,0);
		if(direction.Equals(Direction.Up)) {
			trajectory.y = 1;
		}
		else if(direction.Equals(Direction.Right)) {
			trajectory.x = 1;
		}
		else if(direction.Equals(Direction.Down)) {
			trajectory.y = -1;
		}
		else if(direction.Equals(Direction.Left)) {
			trajectory.x = -1;
		}

		// Set trajectory (hard-coded to right)
		bullet.GetComponent<Projectile>().SetTrajectory(trajectory);
	}
}
