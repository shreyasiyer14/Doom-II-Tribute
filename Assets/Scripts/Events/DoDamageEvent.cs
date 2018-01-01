using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamageEvent : AbstractFloatEvent {
	private GameObject entity;
	private GameObject instigator;
	private HealthComponent instigatorHealthComp;

	public DoDamageEvent (GameObject entity, GameObject instigator, HealthComponent instigatorHealthComp) {
		this.entity = entity;
		this.instigator = instigator;
		this.instigatorHealthComp = instigatorHealthComp;

		this.AddListener (instigatorHealthComp.onTakeDamageEvent);
	}
}
