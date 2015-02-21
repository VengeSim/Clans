using UnityEngine;
using UnityEditor;
using System;
using System.Collections;




[CanEditMultipleObjects]
[CustomEditor(typeof(CombatantController))]

public class Inspector_CombatantController : Editor 
{
	public override void OnInspectorGUI()
	{
		CombatantController script = (CombatantController)target;
		//GameObject gObject = script.gameObject;
		
		DrawDefaultInspector();
		
		EditorGUILayout.LabelField(String.Format ("Name : {0}", script.stats.Name));
		EditorGUILayout.LabelField(String.Format ("Reaction : {0}", script.stats.Reaction));
		EditorGUILayout.LabelField(String.Format ("Speed : {0}", script.stats.Speed));
		EditorGUILayout.LabelField(String.Format ("Strength : {0}", script.stats.Strength));
		EditorGUILayout.LabelField(String.Format ("Damage : {0}", script.stats.Damage));
		EditorGUILayout.LabelField(String.Format ("Critical Damage : {0}", script.stats.CriticalDamage));
		
		
	}
}