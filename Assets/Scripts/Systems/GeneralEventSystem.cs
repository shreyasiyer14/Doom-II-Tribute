using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralEventSystem : EventSystem {
	public static GeneralEventSystem instance;

	void Awake () {
		if (instance != null) {
			return;
		}
		instance = this;
	}

	public static void send (AbstractEntityEvent incomingEvent) {
		incomingEvent.Invoke (incomingEvent.entity);
	}

	public static void send (AbstractFloatEvent incomingEvent, float damage) {
		incomingEvent.Invoke (damage);
	}

	public static void send (AbstractIntEvent incomingEvent, int slot) {
		incomingEvent.Invoke (slot);
	}
}
