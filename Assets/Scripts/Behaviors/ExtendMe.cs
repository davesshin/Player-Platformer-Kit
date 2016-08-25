using UnityEngine;
using System.Collections;

// This script provides a common set of extensions for many of the other scripts to implement

public abstract class ExtendMe : MonoBehaviour {

	public Buttons[] inputButtons;
	public MonoBehaviour[] dissableScripts;

	protected InputState inputState;
	protected Rigidbody2D physics;
	protected CollisionState collisionState;

	protected virtual void Awake(){
		inputState = GetComponent<InputState> ();
		physics = GetComponent<Rigidbody2D> ();
		collisionState = GetComponent<CollisionState> ();
	}

	protected virtual void ToggleScripts(bool value){
		foreach (var script in dissableScripts) {
			script.enabled = value;
		}
	}
}
