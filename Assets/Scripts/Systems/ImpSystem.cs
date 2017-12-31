using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpSystem : NPCSystem {
	
	// Update is called once per frame
	override void Update () {
		foreach (GameObject impGameObject in EntityManager.instance.getObjectsOfType<EntityComponent>()) {

		}
	}
}
