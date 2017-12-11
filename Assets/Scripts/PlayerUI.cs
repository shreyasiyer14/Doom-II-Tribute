using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {
	[SerializeField] private Image crosshair;

	void Start () {
		
	}
	
	void Update () {
		crosshair.rectTransform.position = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0.0f);
	}
}
