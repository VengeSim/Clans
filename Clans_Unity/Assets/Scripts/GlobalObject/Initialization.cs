using System;
using System.Reflection;
using UnityEngine;
using Venge;

[assembly:AssemblyVersion("0.0.*")]

public class Initialization : GlobalBehaviour 
{
		
	public bool DebugMode = true;
	public int VersionMajor = 0;
	public int VersionMinor = 0;
	public string Version;
	
	[HideInInspector]
	public int VersionBuild = 0;
	[HideInInspector]
	public int VersionRevision = 0;
	
	
	
	void Start()
	{
		DontDestroyOnLoad(this.gameObject);
	
	
		this.VersionBuild = Assembly.GetExecutingAssembly ().GetName ().Version.Build;
		this.VersionRevision = Assembly.GetExecutingAssembly ().GetName ().Version.Revision;
		this.Version =  String.Format("{0}.{1}.{2}.{3}", this.VersionMajor, this.VersionMinor, this.VersionBuild, this.VersionRevision);
		
		
		
		
		if(Global.Save.SaveFilesExists())
		{
			//Load Data
		}else{
			
			Global.Save.CreateSaveFiles();
		}
		
		
	}
	
}
