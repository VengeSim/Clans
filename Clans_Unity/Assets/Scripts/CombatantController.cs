using UnityEngine;
using System.Collections;
using Venge;

public class CombatantController : MonoBehaviour {

	public ArenaController battleController;
	public CombatantStats stats;
	[HideInInspector]
	public GameObject sprite;
	
	protected Direction direction;
	
	public Direction Direction
	{
		get
		{
			return this.direction;
		}
		set
		{
			float newAngle = 0f;
			if(value == Direction.North){ newAngle = 0f;}
			if(value == Direction.East){ newAngle = 90f;}
			if(value == Direction.South){ newAngle = 180f;}
			if(value == Direction.West){ newAngle = 270f;}
			
			this.transform.eulerAngles = new Vector3(0, newAngle, 0);
			this.direction = value;
		}
	}
	
	void Start () 
	{
		this.sprite = transform.FindChild("Sprite").gameObject;
		this.name = stats.Name;
		
	}
	
	
	public void SetPosition(Vector3 pos)
	{
		this.transform.position = pos;
	}
	
}
