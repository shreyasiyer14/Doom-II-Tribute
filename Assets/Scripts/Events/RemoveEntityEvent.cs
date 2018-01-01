using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveEntityEvent : AbstractEntityEvent {
	
	public RemoveEntityEvent (GameObject entity) {
		this.entity = entity;

		this.AddListener (EntityManager.Remove);
	}
}
