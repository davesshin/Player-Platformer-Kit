using UnityEngine;
using System.Collections;

// All credits go to J. Freeman for the scripts found in the "Controls" folder,
// which helped provide a solid modular foundation for this platformer kit

public class PlayerManager : MonoBehaviour {

	private InputState inputState;
	private Walk walkBehavior;
	private Animator animator;
	private CollisionState collisionState;

	void Awake() {
		inputState = GetComponent<InputState>();
		walkBehavior = GetComponent<Walk>();
		animator = GetComponent<Animator>();
		collisionState = GetComponent<CollisionState>();
	}
	
	void Update() {
		if (collisionState.standing) {
			ChangeAnimationState(0);
		}

		if (inputState.absVelX > 0) {
			ChangeAnimationState(1);
		}

		if (inputState.absVelY > 0) {
			ChangeAnimationState(2);
		}
		animator.speed = walkBehavior.running ? walkBehavior.speedMultiplier : 1;

		if (!collisionState.standing && collisionState.onWall) {
			ChangeAnimationState(3);
		}
	}

	void ChangeAnimationState(int value) {
		animator.SetInteger ("AnimState", value);
	}
}
