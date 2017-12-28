using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ImpController : AbstractAIBehavior {
	private Transform player;
	private Direction spriteCode;
	private Animator anim;

	private List<Direction> parameterList = new List<Direction> ();

	void Start () {
		player = Camera.main.transform;
		anim = GetComponent<Animator> ();
		parameterList.Add (Direction.Forward);
		parameterList.Add (Direction.Back);
		parameterList.Add (Direction.Left);
		parameterList.Add (Direction.Right);
		parameterList.Add (Direction.ForwardLeft);
		parameterList.Add (Direction.ForwardRight);
		parameterList.Add (Direction.BackwardLeft);
		parameterList.Add (Direction.BackwardRight);
	}

	private void ResetAllParams () {
		if (parameterList.Count == 0)
			return;
		foreach (Direction param in parameterList) {
			if (param != spriteCode)
				anim.SetBool (anim.GetParameter(Array.IndexOf(Enum.GetValues(param.GetType()), param)).name, false);
		}
		return;
	}
	
	void Update () {
		transform.LookAt (player);
		spriteCode = ChangeSpriteCode (GetDotWithPlayer (player));

		ResetAllParams ();
		anim.SetBool (anim.GetParameter(Array.IndexOf(Enum.GetValues(spriteCode.GetType()), spriteCode)).name, true);
	}
}
