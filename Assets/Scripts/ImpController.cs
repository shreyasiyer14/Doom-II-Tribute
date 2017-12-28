using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpController : AbstractAIBehavior {
	private Transform player;
	private Direction spriteCode;

	void Start () {
		player = Camera.main.transform;	
	}
	
	void Update () {
		transform.LookAt (player.forward);
		spriteCode = ChangeSpriteCode (GetDotWithPlayer (player));
	}
}
