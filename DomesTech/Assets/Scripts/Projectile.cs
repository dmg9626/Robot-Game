using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	public float lifeSpan;
	private float time = 0;
	public float speed;
	public Projectile() {
		
	}

	public void SetTrajectory(Vector2 trajectory) {
		GetComponent<Rigidbody2D>().velocity = trajectory * speed;
		Debug.Log("Trajectory: " + trajectory);
	}
	
	void Update () {
		if(time > lifeSpan) {
			Destroy(gameObject);
		}
		else {
			time += Time.deltaTime;
		}
	}
}
