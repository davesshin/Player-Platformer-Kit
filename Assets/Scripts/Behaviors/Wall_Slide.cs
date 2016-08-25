using UnityEngine;
using System.Collections;

// This script modifies much of Wall_Latch to allow the player to slide down the wall
// Again, by manipulating the player's gravity, we create the illusion of friction

public class Wall_Slide : Wall_Latch {
	
	private float deltaT = 0f;

	public float slideVelocity = -5f;
	public float slideMultiplier = 5f;
	public GameObject dustPrefab;
	public float dustSpawnDelay = .5f;

	override protected void Update() {
		
		base.Update();
		if (attachedToWall && !collisionState.standing) {
			var velY = slideVelocity;

			if(inputState.GetButtonValue(inputButtons[0]))
				velY *= slideMultiplier;

			physics.velocity = new Vector2(physics.velocity.x, velY);

			if(deltaT > dustSpawnDelay){
				var dust = Instantiate(dustPrefab);
				var pos = transform.position;
				pos.y += 2;
				dust.transform.position = pos;
				dust.transform.localScale = transform.localScale;
				deltaT = 0;

			}
			deltaT += Time.deltaTime;
		}
	}

	override protected void Attached() {
		physics.velocity = Vector2.zero;
	}

	override protected void Detached() {
		deltaT = 0;
	}
}
