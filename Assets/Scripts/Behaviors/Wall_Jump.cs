using UnityEngine;
using System.Collections;

// This script allows the player to jump off walls using much of the basic jump behavior
// In the Wall_Latch & Wall_Slide scripts, jumping was disabled -- but this script overrides those.

public class Wall_Jump : ExtendMe {

	public Vector2 jumpVelocity = new Vector2(50, 200);
	public bool jumpingOffWall;
	public float resetDelay = .2f;

	private float deltaT = 0;

	void Update() {
		if (collisionState.onWall && !collisionState.standing) {

			var jumping = inputState.GetButtonValue(inputButtons[0]);

			if(jumping && !jumpingOffWall){

				inputState.direction = inputState.direction == Directions.Right ? Directions.Left : Directions.Right;
				physics.velocity = new Vector2(jumpVelocity.x * (float)inputState.direction, jumpVelocity.y);

				ToggleScripts(false);
				jumpingOffWall = true;
			}
		}

		if (jumpingOffWall) {
			deltaT += Time.deltaTime;
			if (deltaT > resetDelay){
				ToggleScripts(true);
				jumpingOffWall = false;
				deltaT = 0;
			}
		}
	}
}
