using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon")]
public class Weapon : ScriptableObject {
	public string name;
	public float damage;
	public AnimationClip fireAnimation;
	public Sprite fireAdditionalSprite;
	public Sprite mainSprite;
	public Sprite droppedSprite;
	public bool isSingleShot;
}
