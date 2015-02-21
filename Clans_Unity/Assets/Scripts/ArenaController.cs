using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

using Venge;

public class ArenaController : MonoBehaviour 
{
	public UIController UIController;
	
	public ArenaCamera ArenaCamera;
	public GameObject GridObject;
	
	public GameObject CombatantPrefab;
	
	
	[HideInInspector]
	public List<CombatantController> Combatants;
	
	void Start () 
	{	

		//this.Combatants.Add( this.SpawnCombatant(new CombatantStats("Venge")));
		//this.Combatants.Add( this.SpawnCombatant(new CombatantStats("Judge")));
		
		
		
	}
	
	void Update () 
	{
		
	}
	
	
	protected CombatantController SpawnCombatant(CombatantStats stats)
	{
		//Spawn Prefab
		GameObject prefab = Instantiate(CombatantPrefab, new Vector3(), new Quaternion()) as GameObject;
		
		//Get CombatantController from prefab
		CombatantController combatant = prefab.GetComponent<CombatantController>();
		
		//Initialize
		combatant.battleController = this;
		combatant.stats = stats;
	
		return combatant;
	}
}
