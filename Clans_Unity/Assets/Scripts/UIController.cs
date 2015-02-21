using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Venge;

public class UIController : MonoBehaviour 
{
	public ArenaController BattleController;
	public Camera UICamera;
	
	public Text Name;
	public Text Reaction;
	public Text Speed;
	public Text Strength;
	public Text Damage;
	public Text CriticalDamage;
	

	void Start () 
	{
	
	}
	
	void Update () 
	{
	
	}
	
	public void SetStats(CombatantStats stats)
	{
		Name.text = stats.Name;
		Reaction.text = stats.Reaction.ToString();
		Speed.text = stats.Speed.ToString();
		Strength.text = stats.Strength.ToString();
		Damage.text = stats.Damage.ToString();	
		CriticalDamage.text = stats.CriticalDamage.ToString();
		
		
		
	}
}
