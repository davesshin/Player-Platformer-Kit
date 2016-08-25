using UnityEngine;
using System.Collections;

// This script allows the player to shoot actual projectiles (eg. grenade) in-game
// For *how* this works, check out the "Projectile" script

public class FireProjectile : ExtendMe {

	public float shootDelay = .5f;
	public GameObject projectilePrefab;
	public Vector2 firePosition = Vector2.zero;
	public Color wireColor = Color.red;
	public float wireRadius = 3f;

	private float deltaT = 0f;

	void Update() {

		if (projectilePrefab != null) {
			var canFire = inputState.GetButtonValue(inputButtons[0]);

			if (canFire && deltaT > shootDelay){
				CreateProjectile(CalculateFirePosition());
				deltaT = 0;
			}
			deltaT += Time.deltaTime;
		}
	}

	Vector2 CalculateFirePosition(){
		var pos = firePosition;
		pos.x *= (float)inputState.direction;
		pos.x += transform.position.x; 
		pos.y += transform.position.y;
		return pos;
	}

	public void CreateProjectile(Vector2 pos){
		var copy = Instantiate (projectilePrefab, pos, Quaternion.identity) as GameObject;
		copy.transform.localScale = transform.localScale;
	}

	// OnDrawGizmos is for when you want to draw gizmos that are also pickable and always drawn.
	// Gizmos allow you to visualize important objects in your scene without having them show up in-game
	// eg. A circle to help us visualize where projectileOrigin (from which grenade copy spawns) is
	// Note that OnDrawGizmos will use a mouse position that is relative to the Scene View

	void OnDrawGizmos() {
		Gizmos.color = wireColor;
		var pos = firePosition;

		if(inputState != null)
			pos.x *= (float)inputState.direction;

		pos.x += transform.position.x; 
		pos.y += transform.position.y;
		Gizmos.DrawWireSphere (pos, wireRadius);
	}
}
