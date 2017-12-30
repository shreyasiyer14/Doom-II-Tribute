using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : Component {
	[SerializeField] private float health;

	public void onTakeDamageEvent (float damage) {
		health = Mathf.Clamp (health - damage, 0f, 100f);
		return;
	}

	public float getHealth () {
		return health;
	}
}
