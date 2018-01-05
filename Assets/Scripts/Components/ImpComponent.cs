using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ImpComponent : NPCComponent {
	public float searchRadius;
	public GameObject attackProjectile;

	public void GenerateProjectile () {
		GameObject newProjectile = (GameObject) Instantiate (attackProjectile, transform.position, transform.rotation);	
		GeneralEventSystem.send (new NewEntityEvent(newProjectile));
	}
}
