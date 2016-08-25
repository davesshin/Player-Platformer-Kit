using UnityEngine;
using System.Collections;

// This script uses "OnDestroy" which is called when the MonoBehaviour will be destroyed
// "OnDestroy" will only be called on game objects that have previously been active
// Eg. The friction dust effect copy is destroyed to give it the "poof" illusion

public class Destroy_GameObject : MonoBehaviour {
	
	void OnDestroy() {
		Destroy(gameObject);

	}
}
