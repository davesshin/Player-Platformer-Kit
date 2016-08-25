using UnityEngine;
using System.Collections;

// This script allows the player to jump dynamically, according to how long the input key's pressed
// Basically, this gives the player the option to jump & high jump (like in the Mario games)

public class Jump_High : Jump {

	public float highJumpRest = .15f;
	public float heightMultiplier = 1.2f;
	public bool highJump;
	public bool isHighJumping;

	protected override void Update() {

		var jumping = inputState.GetButtonValue (inputButtons[0]);
		var timePressed = inputState.GetButtonHoldTime (inputButtons[0]);

		if (!jumping)
			highJump = false;

		if (collisionState.standing && isHighJumping)
			isHighJumping = false;

		base.Update();

		if (highJump && !collisionState.standing && timePressed > highJumpRest) {
			var v = physics.velocity;
			physics.velocity = new Vector2(v.x, jumpingVelocity * heightMultiplier);
			highJump = false;
			isHighJumping = true;
		}
	}

	protected override void OnJump() { 
		base.OnJump();
		highJump = true;
	}
}
