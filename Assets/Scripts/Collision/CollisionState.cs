using UnityEngine;
using System.Collections;

// This script basically manages the collision states and relationships
// between the player and other physical in-game objects, such as the floor.

public class CollisionState : MonoBehaviour {
	
	private InputState inputState;

	public LayerMask collisionLayer;
	public bool standing;
	public bool onWall;
	public Vector2 bottomPosition = Vector2.zero;
	public Vector2 rightPosition = Vector2.zero;
	public Vector2 leftPosition = Vector2.zero;
	public float wireCollisionRadius = 10f;
	public Color wireCollisionColor = Color.green;

	void Awake() {
		inputState = GetComponent<InputState> ();
	}

	void FixedUpdate() {
		var pos = bottomPosition;
		pos.x += transform.position.x;
		pos.y += transform.position.y;

		standing = Physics2D.OverlapCircle (pos, wireCollisionRadius, collisionLayer);

		pos = inputState.direction == Directions.Right ? rightPosition : leftPosition;
		pos.x += transform.position.x;
		pos.y += transform.position.y;

		onWall = Physics2D.OverlapCircle (pos, wireCollisionRadius, collisionLayer);
	}

	void OnDrawGizmos() {
		Gizmos.color = wireCollisionColor;

		var positions = new Vector2[] {rightPosition, bottomPosition, leftPosition};

		foreach (var position in positions) {

			var pos = position;
			pos.x += transform.position.x;
			pos.y += transform.position.y;

			Gizmos.DrawWireSphere(pos, wireCollisionRadius);
		}
	}
}
