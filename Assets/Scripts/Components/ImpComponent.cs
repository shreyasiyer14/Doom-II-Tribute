using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ImpComponent : NPCComponent {
	public float searchRadius;
	public GameObject attackProjectile;

	[System.NonSerialized]
	public Direction spriteCode;
	[System.NonSerialized]
	public Transform sprite;

	public void GenerateProjectile () {
		GameObject newProjectile = (GameObject) Instantiate (attackProjectile, transform.position, transform.rotation);	
		EntitySystem.send (new NewEntityEvent(newProjectile));
	}
}
