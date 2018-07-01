using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    /// <summary>
    /// Time to wait for collision before disappearing
    /// </summary>
    public float lifeSpan;

    /// <summary>
    /// Time counter
    /// </summary>
    private float time = 0;

    /// <summary>
    /// Projectile speed
    /// </summary>
    public float speed;
	
	void Update () {
		if(time > lifeSpan) {
			Destroy(gameObject);
		}
		else {
			time += Time.deltaTime;
		}
	}

    /// <summary>
    /// Shoots projectile in given direction
    /// </summary>
    /// <param name="vector">Vector</param>
    public void Shoot(Vector2 vector)
    {
        // Set velocity
        GetComponent<Rigidbody2D>().velocity = vector * speed;
        GameController.LogPhysics.Log("Trajectory: " + vector);

        // Set rotation
        if (!DirectionHelper.IsVertical(DirectionHelper.VectorToDirection(vector)))
        {
            Quaternion rotation = transform.rotation;
            rotation.eulerAngles = new Vector3(0, 0, 90F);
            transform.rotation = rotation;
        }
    }
}
