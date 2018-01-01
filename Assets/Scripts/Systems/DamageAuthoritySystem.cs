using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAuthoritySystem : EventSystem {
	public static DamageAuthoritySystem instance;

	void Awake () {
		if (instance != null) {
			return;
		}
		instance = this;
	}

	public static void send (AbstractFloatEvent incomingEvent, float damage) {
		incomingEvent.Invoke (damage);
	}
}
