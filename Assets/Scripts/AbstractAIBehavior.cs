using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class AbstractAIBehavior : MonoBehaviour {
	protected enum Direction {Forward, ForwardLeft, Left, BackwardLeft, Back, BackwardRight, Right, ForwardRight, Default};

	protected float GetDotWithPlayer(Transform playerCamera) {
		float dot = Vector3.Dot (playerCamera.forward, transform.forward)/(playerCamera.forward.magnitude * transform.forward.magnitude);
		return dot;
	}

	protected Direction ChangeSpriteCode (float dotValue) {
		if (dotValue <= 1.0f && dotValue > 0.71f) {
			return Direction.Forward;
		} else if (dotValue <= 0.71f && dotValue > 0.1f) {
			return Direction.ForwardLeft;
		} else if (dotValue <= 0.1f && dotValue >= 0.0f) {
			return Direction.Left;
		} else if (dotValue < 0.0f && dotValue > -0.71f) {
			return Direction.BackwardLeft;
		} else if (dotValue <= -0.71f && dotValue > -1.0f) {
			return Direction.Back;
		}
		return Direction.Default;
	}
}
