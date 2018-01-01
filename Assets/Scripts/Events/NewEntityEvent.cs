using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NewEntityEvent : AbstractEntityEvent {
	
	public NewEntityEvent (GameObject entity) {
		this.entity = entity;

		this.AddListener (EntityManager.Add);
	}
}
