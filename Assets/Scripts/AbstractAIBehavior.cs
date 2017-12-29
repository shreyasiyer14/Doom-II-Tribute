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
		
	protected Direction ChangeSpriteCode (float dotValue, float sign, float transformAngle) {
		Debug.Log (transformAngle);
		if (transformAngle >= 0.0f && transformAngle < 5.0f)
			return Direction.Back;
		else if (transformAngle >= 5.0f && transformAngle < 30.0f) {
			if (sign == -1.0f)
				return Direction.BackwardLeft;
			else
				return Direction.BackwardRight;
		} else if (transformAngle >= 30.0f && transformAngle < 50.0f) {
			if (sign == -1.0f)
				return Direction.Left;
			else
				return Direction.Right;
		} else if (transformAngle >= 50.0f && transformAngle < 85.0f) {
			if (sign == -1.0f)
				return Direction.ForwardLeft;
			else
				return Direction.ForwardRight;
		} else if (transformAngle >= 85.0f) {
			return Direction.Forward;
		}

		if (dotValue <= 1.0f && dotValue > 0.95f) {
			return Direction.Back;
		} else if (dotValue <= 0.9f && dotValue > 0.3f) {
			if (sign == -1.0f)
				return Direction.BackwardLeft;
			else 
				return Direction.BackwardRight;
		} else if (dotValue <= 0.3f && dotValue >= -0.3f) {
			if (sign == -1.0f)
				return Direction.Left;
			else
				return Direction.Right;
		} else if (dotValue < -0.3f && dotValue > -0.95f) {
			if (sign == -1.0f)
				return Direction.ForwardLeft;
			else
				return Direction.ForwardRight;
		} else if (dotValue <= -0.95f && dotValue >= -1.0f) {
			return Direction.Forward;
		}

		return Direction.Default;
	}

	protected float AngleBetweenTransforms (Transform other) {
		return Vector3.Angle (transform.position, other.position);
	}
}
