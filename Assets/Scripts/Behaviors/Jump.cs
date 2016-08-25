using UnityEngine;
using System.Collections;

// This script allows the player to jump and double-jump (or more!)

public class Jump : ExtendMe {

	public float jumpingVelocity = 120f;
	public float jumpingRest = .1f;
	public int jumpingLimit = 2; // double jump = 2

	protected float sinceLastJump = 0;
	protected int jumpsLeft = 0;

	protected virtual void Update() {
		var jumping = inputState.GetButtonValue (inputButtons [0]);
		var timePressed = inputState.GetButtonHoldTime (inputButtons [0]);

		if (collisionState.standing) {
			if (jumping && timePressed < .1f) {
				jumpsLeft = jumpingLimit - 1;
				OnJump();
			}
		} else {
			if (jumping && timePressed < .1f && Time.time - sinceLastJump > jumpingRest) {
				if (jumpsLeft > 0) {
					OnJump();
					jumpsLeft--;
				}
			}
		}
	}

	protected virtual void OnJump(){
		var v = physics.velocity;
		sinceLastJump = Time.time;
		physics.velocity = new Vector2 (v.x, jumpingVelocity);
	}
}
