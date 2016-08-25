using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// All credits go to J. Freeman for the scripts found in the "Controls" folder,
// which helped provide a solid modular foundation for this platformer kit

public class ButtonState {
	public bool value;
	public float timePressed = 0;
}

public enum Directions {
	Left = -1,
	Right = 1
}

public class InputState : MonoBehaviour {

	public Directions direction = Directions.Right;
	public float absVelX = 0f;
	public float absVelY = 0f;

	private Rigidbody2D physics;
	private Dictionary<Buttons, ButtonState> buttonStates = new Dictionary<Buttons, ButtonState>();

	void Awake() {
		physics = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate() {
		absVelX = Mathf.Abs (physics.velocity.x);
		absVelY = Mathf.Abs (physics.velocity.y);

	}
	public void SetButtonValue(Buttons key, bool value) {
		if (!buttonStates.ContainsKey(key))
			buttonStates.Add(key, new ButtonState());

		var state = buttonStates [key];

		if (state.value && !value) {
			state.timePressed = 0;
		} else if (state.value && value) {
			state.timePressed += Time.deltaTime;
		}

		state.value = value;
	}

	public bool GetButtonValue(Buttons key) {
		if (buttonStates.ContainsKey (key))
			return buttonStates [key].value;
		else
			return false;
	}

	public float GetButtonHoldTime(Buttons key) {
		if (buttonStates.ContainsKey(key))
			return buttonStates[key].timePressed;
		else
			return 0;
	}
}
