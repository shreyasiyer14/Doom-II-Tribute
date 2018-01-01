using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TakeDamageEvent : AbstractFloatEvent {

	private GameObject entity;
	private GameObject instigator;
	private HealthComponent entityHealthComp;

	public TakeDamageEvent (GameObject entity, GameObject instigator, HealthComponent entityHealthComp) {
		this.entity = entity;
		this.instigator = instigator;
		this.entityHealthComp = entityHealthComp;

		this.AddListener (entityHealthComp.onTakeDamageEvent);
	}
}
