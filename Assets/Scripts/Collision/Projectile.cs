using UnityEngine;
using System.Collections;

// This script controls how the projectile (eg. grenade) works
// A velocity is applied to the projectile, after which it bounces, slows down, & gets deleted 
// There is also the option to produce an "explosion" animation at the end

public class Projectile : MonoBehaviour {	

	private Rigidbody2D physics;

	public Vector2 initialVel = new Vector2(100, -100);
	public int bounceNo = 3; 
	// fun fact: even more complex games continue to "time" projectile longevity like this
	public GameObject explosion; // drag your explosion animation prefab here, if you'd like

	void Awake() {
		physics = GetComponent<Rigidbody2D>(); 
	}

	void Start() {
		var startVelX = initialVel.x * transform.localScale.x;
		physics.velocity = new Vector2 (startVelX, initialVel.y);
	}

	void OnCollisionEnter2D (Collision2D target) {
		if (target.gameObject.transform.position.y < transform.position.y) {
			bounceNo--;
		}

		if (bounceNo <= 0) {
			Destroy (gameObject); // destroy the grenade

			GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
			Destroy (expl, 1); // delete the explosion after 1 seconds
		}
	}
}
