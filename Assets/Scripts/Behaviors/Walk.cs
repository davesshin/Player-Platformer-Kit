using UnityEngine;
using System.Collections;

// This script allows the player to walk and run, at designated speeds

public class Walk : ExtendMe {

	public float speed = 55f; // walking speed - this is the default
	public float speedMultiplier = 2f; // running speed multiplier
	public bool running; // to check if running or not 

	void Update() {
		
		running = false;
		var facingLeft = inputState.GetButtonValue (inputButtons [1]);
		var facingRight = inputState.GetButtonValue (inputButtons [0]);
		var run = inputState.GetButtonValue (inputButtons [2]);

		if (facingLeft || facingRight) {
			var newSpeed = speed; 
			if (speedMultiplier > 0 && run) {
				newSpeed *= speedMultiplier;
			}
			var velocityX = newSpeed * (float)inputState.direction;
			physics.velocity = new Vector2(velocityX, physics.velocity.y);
		}
	}
}
