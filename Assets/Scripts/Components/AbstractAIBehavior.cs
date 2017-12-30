using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

abstract public class AbstractAIBehavior : Component {
	protected List<Direction> parameterList = new List<Direction> {Direction.Forward, Direction.Back, Direction.Left, Direction.Right, 
									Direction.ForwardLeft, Direction.ForwardRight, Direction.BackwardLeft, Direction.BackwardRight};

	protected enum Direction : int {Forward, Back, Left, Right, ForwardLeft, ForwardRight, BackwardLeft, BackwardRight, Default};

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
		
	protected float GetDotWithPlayer(Transform playerCamera) {
		float dot = Vector3.Dot (playerCamera.forward, transform.forward)/(playerCamera.forward.magnitude * transform.forward.magnitude);
		return dot;
	}

	protected float AngleBetweenTransforms (Transform other) {
		return Vector3.Angle (transform.forward, other.forward);
	}

	protected float DistanceWithPlayer (Transform player) {
		return Vector3.Distance (transform.position, player.position);
	}
		
	protected float GetRotateDirection (Transform playerCamera) {
		float dir = AngleDir(transform.forward, playerCamera.position - transform.position, transform.up);
		return dir;
	}

	private float AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up) {
		Vector3 perp = Vector3.Cross(fwd, targetDir);
		float dir = Vector3.Dot(perp, up);

		if (dir > 0.0f) {
			return -1.0f;
		} else if (dir < 0.0f) {
			return 1.0f;
		} else {
			return 0f;
		}
	}
}
