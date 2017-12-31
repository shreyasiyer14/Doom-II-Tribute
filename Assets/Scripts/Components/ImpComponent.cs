using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ImpComponent : NPCComponent {
	public float searchRadius;
	public GameObject attackProjectile;
	public Direction spriteCode;
	public Transform sprite;

	public void AttackEntity () {
		Instantiate (attackProjectile, transform.position, transform.rotation);	
	}
}
