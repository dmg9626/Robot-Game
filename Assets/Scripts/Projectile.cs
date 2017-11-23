using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	public float time;
	public float speed;
	public Projectile() {
		
	}

	public void SetTrajectory(Vector2 trajectory) {
		trajectory.x *= speed;
		trajectory.y *= speed;
		GetComponent<Rigidbody2D>().velocity = trajectory;
	}
	
	void Update () {
		if(time > 4) {
			Destroy(gameObject);
		}
		else {
			time += Time.deltaTime;
		}
	}
}
