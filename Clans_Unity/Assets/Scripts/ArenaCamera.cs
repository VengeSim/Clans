using UnityEngine;
using System.Collections;

public class ArenaCamera : MonoBehaviour {
	
	public ArenaController bController;
	public GridOverlay gOverlay;
	
	protected Vector3 initialPosition;

	
	
	void Start () 
	{
		bController = GameObject.Find("ArenaController").GetComponent<ArenaController>();
		gOverlay = gameObject.GetComponent<GridOverlay>();
		
		initialPosition = this.transform.position;
	}
	
	void Update () 
	{
		
	}
	
	public void RotateRight()
	{
		//transform.RotateAround(bController.SelectedCombatant.sprite.transform.position, Vector3.up, -20);
		
	}
	
	public void RotateLeft()
	{
		//transform.RotateAround(bController.SelectedCombatant.sprite.transform.position, Vector3.up, 20);
			
	}
	
	public void LookAtSelected()
	{
		//transform.LookAt(bController.SelectedCombatant.sprite.transform.position);
	}
	
	public void CenterPositionAtSelected()
	{
		//float sx = bController.SelectedCombatant.transform.position.x + initialPosition.x;
		//float sy = bController.SelectedCombatant.transform.position.y + initialPosition.y;
		//float sz = initialPosition.z;
		
		//transform.position = new Vector3(sx, sy, sz);
		
	}
	
}
