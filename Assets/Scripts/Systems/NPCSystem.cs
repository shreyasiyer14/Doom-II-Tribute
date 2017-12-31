using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class NPCSystem : MonoBehaviour, EventSystem {
	protected NPCComponent.Direction ChangeSpriteCode (float sign, float transformAngle) {
		if (transformAngle <= 180.0f && transformAngle >= 165.0f)
			return NPCComponent.Direction.Forward;
		else if (transformAngle > 110.0f && transformAngle < 165.0f) {
			if (sign == -1.0f)
				return NPCComponent.Direction.ForwardLeft;
			else
				return NPCComponent.Direction.ForwardRight;
		} else if (transformAngle > 70.0f && transformAngle <= 110.0f) {
			if (sign == -1.0f)
				return NPCComponent.Direction.Left;
			else
				return NPCComponent.Direction.Right;
		} else if (transformAngle > 15.0f && transformAngle <= 70.0f) {
			if (sign == -1.0f)
				return NPCComponent.Direction.BackwardLeft;
			else
				return NPCComponent.Direction.BackwardRight;
		} else if (transformAngle <= 15.0f) {
			return NPCComponent.Direction.Back;
		}

		return NPCComponent.Direction.Default;
	}

	protected float GetDotWithPlayer(GameObject entity, Transform playerCamera) {
		float dot = Vector3.Dot (playerCamera.forward, entity.transform.forward)/(playerCamera.forward.magnitude * entity.transform.forward.magnitude);
		return dot;
	}

	protected float AngleBetweenTransforms (GameObject entity, Transform other) {
		return Vector3.Angle (entity.transform.forward, other.forward);
	}

	protected float DistanceWithPlayer (GameObject entity, Transform player) {
		return Vector3.Distance (entity.transform.position, player.position);
	}

	protected float GetRotateDirection (GameObject entity, Transform playerCamera) {
		float dir = AngleDir(entity.transform.forward, playerCamera.position - entity.transform.position, entity.transform.up);
		return dir;
	}

	protected float AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up) {
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

	// Use this for initialization
	protected virtual void Start () {
		
	}
	
	// Update is called once per frame
	protected virtual void Update () {

	}
}
