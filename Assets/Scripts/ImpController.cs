using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ImpController : AbstractAIBehavior {
	private Transform player;
	private Direction spriteCode;
	private Animator anim;
	private Transform sprite;

	void Start () {
		player = Camera.main.transform;
		sprite = transform.GetChild (0);
		anim = sprite.gameObject.GetComponent<Animator> ();
	}
		
	void ResetAllParams () {
		foreach (Direction param in parameterList) {
			if (param != spriteCode)
				anim.SetBool (anim.GetParameter(Array.IndexOf(Enum.GetValues(param.GetType()), param)).name, false);
		}
		return;
	}

	void Update () {
		sprite.LookAt (player);

		float sign = GetRotateDirection (player);
		float dot = GetDotWithPlayer (player);
		float transAng = AngleBetweenTransforms (player);

		spriteCode = ChangeSpriteCode (dot, sign, transAng);

		ResetAllParams ();

		if (spriteCode == Direction.BackwardRight || spriteCode == Direction.ForwardRight || spriteCode == Direction.Right) {
			anim.SetBool (anim.GetParameter(Array.IndexOf(Enum.GetValues(spriteCode.GetType()), spriteCode) - 1).name, true);
			transform.GetChild (0).GetComponent<SpriteRenderer> ().flipX = true;
		} else {
			anim.SetBool (anim.GetParameter(Array.IndexOf(Enum.GetValues(spriteCode.GetType()), spriteCode)).name, true);
			transform.GetChild (0).GetComponent<SpriteRenderer> ().flipX = false;
		}
	}
}
