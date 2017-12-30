using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

abstract public class AbstractAIBehavior : MonoBehaviour {
	protected List<Direction> parameterList = new List<Direction> {Direction.Forward, Direction.Back, Direction.Left, Direction.Right, 
									Direction.ForwardLeft, Direction.ForwardRight, Direction.BackwardLeft, Direction.BackwardRight};

	protected enum Direction : int {Forward, Back, Left, Right, ForwardLeft, ForwardRight, BackwardLeft, BackwardRight, Default};

	protected float GetDotWithPlayer(Transform playerCamera) {
		float dot = Vector3.Dot (playerCamera.forward, transform.forward)/(playerCamera.forward.magnitude * transform.forward.magnitude);
		return dot;
	}

	protected float GetRotateDirection (Transform playerCamera) {
		float dir = Mathf.Sign(playerCamera.position.x - transform.position.x);
		return dir;
	}
		
	protected Direction ChangeSpriteCode (float sign, float transformAngle) {
		if (transformAngle <= 180.0f && transformAngle >= 165.0f)
			return Direction.Forward;
		else if (transformAngle > 110.0f && transformAngle < 165.0f) {
			if (sign == -1.0f)
				return Direction.ForwardLeft;
			else
				return Direction.ForwardRight;
		} else if (transformAngle > 70.0f && transformAngle <= 110.0f) {
			if (sign == -1.0f)
				return Direction.Left;
			else
				return Direction.Right;
		} else if (transformAngle > 15.0f && transformAngle <= 70.0f) {
			if (sign == -1.0f)
				return Direction.BackwardLeft;
			else
				return Direction.BackwardRight;
		} else if (transformAngle <= 15.0f) {
			return Direction.Back;
		}
			
		return Direction.Default;
	}

	protected float AngleBetweenTransforms (Transform other) {
		return Vector3.Angle (transform.forward, other.forward);
	}
}
