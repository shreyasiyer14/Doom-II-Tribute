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
			if (param != spriteCode) {
				anim.SetBool (anim.GetParameter (Array.IndexOf (Enum.GetValues (param.GetType ()), param)).name, false);
				anim.SetBool (anim.GetParameter (Array.IndexOf (Enum.GetValues (param.GetType ()), param) + 8).name, false);
			}
		}
		return;
	}

	void Update () {
		sprite.LookAt (player);

		float sign = GetRotateDirection (player);
		float transAng = AngleBetweenTransforms (player);

		spriteCode = ChangeSpriteCode (sign, transAng);

		ResetAllParams ();

		if (spriteCode == Direction.BackwardRight || spriteCode == Direction.ForwardRight || spriteCode == Direction.Right) {
			if (DistanceWithPlayer (player) <= 10.0f) {
				anim.SetBool (anim.GetParameter (Array.IndexOf (Enum.GetValues (spriteCode.GetType ()), spriteCode) + 7).name, true);
				anim.SetBool (anim.GetParameter (Array.IndexOf (Enum.GetValues (spriteCode.GetType ()), spriteCode) - 1).name, false);
			} else {
				anim.SetBool (anim.GetParameter (Array.IndexOf (Enum.GetValues (spriteCode.GetType ()), spriteCode) - 1).name, true);
				anim.SetBool (anim.GetParameter (Array.IndexOf (Enum.GetValues (spriteCode.GetType ()), spriteCode) + 7).name, false);
			}
			transform.GetChild (0).GetComponent<SpriteRenderer> ().flipX = true;
		} else {
			if (DistanceWithPlayer (player) <= 10.0f) {
				anim.SetBool (anim.GetParameter (Array.IndexOf (Enum.GetValues (spriteCode.GetType ()), spriteCode) + 8).name, true);
				anim.SetBool (anim.GetParameter (Array.IndexOf (Enum.GetValues (spriteCode.GetType ()), spriteCode)).name, false);
			} else {
				anim.SetBool (anim.GetParameter (Array.IndexOf (Enum.GetValues (spriteCode.GetType ()), spriteCode)).name, true);
				anim.SetBool (anim.GetParameter (Array.IndexOf (Enum.GetValues (spriteCode.GetType ()), spriteCode) + 8).name, false);
			}
			transform.GetChild (0).GetComponent<SpriteRenderer> ().flipX = false;
		}

	}
}
