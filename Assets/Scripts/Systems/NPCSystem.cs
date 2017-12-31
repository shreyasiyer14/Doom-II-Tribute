using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSystem : MonoBehaviour, EventSystem {
	NPCComponent.Direction ChangeSpriteCode (float sign, float transformAngle) {
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

	float GetDotWithPlayer(GameObject entity, Transform playerCamera) {
		float dot = Vector3.Dot (playerCamera.forward, entity.transform.forward)/(playerCamera.forward.magnitude * entity.transform.forward.magnitude);
		return dot;
	}

	float AngleBetweenTransforms (GameObject entity, Transform other) {
		return Vector3.Angle (entity.transform.forward, other.forward);
	}

	float DistanceWithPlayer (GameObject entity, Transform player) {
		return Vector3.Distance (entity.transform.position, player.position);
	}

	float GetRotateDirection (GameObject entity, Transform playerCamera) {
		float dir = AngleDir(entity.transform.forward, playerCamera.position - entity.transform.position, entity.transform.up);
		return dir;
	}

	float AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up) {
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
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
}
