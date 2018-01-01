using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySystem : EventSystem {
	public static EntitySystem instance;

	void Awake () {
		if (instance != null) {
			return;
		}
		instance = this;
	}

	public static void send (AbstractEntityEvent incomingEvent) {
		incomingEvent.Invoke (incomingEvent.entity);
	}
}
