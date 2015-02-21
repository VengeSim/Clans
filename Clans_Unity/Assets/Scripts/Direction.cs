using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Venge;

namespace Venge
{

	/*
		Add a static method to GridIndex to convert the index to the direction
		e.g
		GridIndex.ConvertToDirection(Direction)
		
		this might be better
		GridIndex.RotateClockwise(index)
	*/
	
	public enum Direction
	{
		North,
		East,
		South,
		West
	}
}
