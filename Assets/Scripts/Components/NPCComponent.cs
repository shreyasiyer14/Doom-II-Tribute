using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(EntityComponent))]
abstract public class NPCComponent : Component {
	[HideInInspector]
	public static List<Direction> parameterList = new List<Direction> {Direction.Forward, Direction.Back, Direction.Left, Direction.Right, 
									Direction.ForwardLeft, Direction.ForwardRight, Direction.BackwardLeft, Direction.BackwardRight};
	[HideInInspector]
	public enum Direction : int {Forward, Back, Left, Right, ForwardLeft, ForwardRight, BackwardLeft, BackwardRight, Default};
	[HideInInspector]
	public Transform entityTransform = null;
}
