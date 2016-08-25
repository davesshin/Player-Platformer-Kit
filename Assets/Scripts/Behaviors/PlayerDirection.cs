using UnityEngine;
using System.Collections;

// This script simply gives us with the direction that the character is facing (either left or right)

public class PlayerDirection : ExtendMe {
	
	void Update () {
		var facingLeft = inputState.GetButtonValue (inputButtons [1]);
		var facingRight = inputState.GetButtonValue (inputButtons [0]);

		if (facingLeft) {
			inputState.direction = Directions.Left;
		} else if (facingRight) {
			inputState.direction = Directions.Right;
		}

		transform.localScale = new Vector3 ((float)inputState.direction, 1, 1);
	}
}
