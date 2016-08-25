using UnityEngine;
using System.Collections;

// This script allows the player to stick onto the wall instead of just falling down
// By manipulating the player's gravity, we create the illusion of friction

public class Wall_Latch : ExtendMe {
	
	protected float defaultF; // original drag Force
	protected float defaultG; // original gravity
	public bool attachedToWall; // to check if attached to wall or not 

	void Start() {
		defaultG = physics.gravityScale;
		defaultF = physics.drag;
	}
	
	protected virtual void Update() {
		if (collisionState.onWall) {
			if (!attachedToWall) {
				Attached();
				ToggleScripts(false);
				attachedToWall = true;
			}
		} else {
			if (attachedToWall) {
				Detached();
				ToggleScripts(true);
				attachedToWall = false;
			}
		}
	}

	protected virtual void Attached() {
		if (physics.velocity.y > 0 && !collisionState.standing) {
			physics.gravityScale = 0;
			physics.drag = 100;
		}
	}

	protected virtual void Detached() {
		if (physics.gravityScale != defaultG) {
			physics.gravityScale = defaultG;
			physics.drag = defaultF;
		}
	}
}
