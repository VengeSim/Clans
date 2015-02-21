using UnityEngine;
using UnityEditor;
using System;
using System.Collections;




[CanEditMultipleObjects]
[CustomEditor(typeof(Global))]

public class Inspector_Global : Editor 
{
	public override void OnInspectorGUI()
	{
		Global script = (Global)target;
		//GameObject gObject = script.gameObject;
		
		DrawDefaultInspector();
		
			if(GUILayout.Button("Open Save Directory"))
			{
				EditorUtility.RevealInFinder(script.Save.Directory);
			}
		
		//script.DebugMode = EditorGUILayout.Toggle("DebugMode", script.DebugMode);
		//EditorGUILayout.LabelField(String.Format ("Version : {0}", script.Version));
	}
}
