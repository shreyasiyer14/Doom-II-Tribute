using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

abstract public class AbstractAIBehavior : MonoBehaviour {
	protected enum Direction : int {Forward, Back, Left, Right, ForwardLeft, ForwardRight, BackwardLeft, BackwardRight, Default};

	protected float GetDotWithPlayer(Transform playerCamera) {
		float dot = Vector3.Dot (playerCamera.forward, transform.forward)/(playerCamera.forward.magnitude * transform.forward.magnitude);
		return dot;
	}

	protected float GetRotateDirection (Transform playerCamera) {
		float dir = Mathf.Sign(playerCamera.position.x - transform.position.x);
		return dir;
	}

	protected Direction ChangeSpriteCode (float dotValue, float sign) {
		if (dotValue <= 1.0f && dotValue > 0.71f) {
			return Direction.Back;
		} else if (dotValue <= 0.71f && dotValue > 0.1f) {
			if (sign == -1.0f)
				return Direction.BackwardLeft;
			else 
				return Direction.BackwardRight;
		} else if (dotValue <= 0.1f && dotValue >= -0.1f) {
			if (sign == -1.0f)
				return Direction.Left;
			else
				return Direction.Right;
		} else if (dotValue < -0.1f && dotValue > -0.71f) {
			if (sign == -1.0f)
				return Direction.ForwardLeft;
			else
				return Direction.ForwardRight;
		} else if (dotValue <= -0.71f && dotValue >= -1.0f) {
			return Direction.Forward;
		}
		return Direction.Default;
	}
}
