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

	public static void send (TakeDamageEvent incomingEvent, float damage) {
		incomingEvent.Invoke (damage);
	}

	public static void send (DoDamageEvent incomingEvent, float damage) {
		incomingEvent.Invoke (damage);
	}
}
