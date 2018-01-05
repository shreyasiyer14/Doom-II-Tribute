using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(EntityComponent))]
abstract public class NPCComponent : Component {
	public static List<Direction> parameterList = new List<Direction> {Direction.Forward, Direction.Back, Direction.Left, Direction.Right, 
									Direction.ForwardLeft, Direction.ForwardRight, Direction.BackwardLeft, Direction.BackwardRight};
	public enum Direction : int {Forward, Back, Left, Right, ForwardLeft, ForwardRight, BackwardLeft, BackwardRight, Default};

	[System.NonSerialized]
	public Direction spriteCode;
	[System.NonSerialized]
	public Transform sprite;
}
