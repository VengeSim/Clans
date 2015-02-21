using UnityEngine;
using System.Collections;

public class GlobalBehaviour : MonoBehaviour 
{

	protected Global global;


	public Global Global{get{return global;}}
	
	void Awake()
	{
		global = GameObject.Find("Global").GetComponent<Global>();
	}
}
