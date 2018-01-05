using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

abstract public class Component : MonoBehaviour {
	[System.NonSerialized]
	public GameObject entity;

	void OnDestroy () {
		GeneralEventSystem.send (new RemoveEntityEvent(entity));
	}
}
