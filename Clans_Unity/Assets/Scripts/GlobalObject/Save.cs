using UnityEngine;
using System;
using System.Collections;
using System.IO;

public class Save : GlobalBehaviour 
{

	public string Directory{get{return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Vengeance/";}}
	
	
	public bool DirectoryExists()
	{
		if(System.IO.Directory.Exists(Directory))
		{
			return true;
		}
		return false;
	}
	
	public void CreateDirectory()
	{
		System.IO.Directory.CreateDirectory(Directory);
	}
	
	public bool SaveFilesExists()
	{
		if(DirectoryExists())
		{
			
			if(System.IO.File.Exists(Directory + "Test.txt"))
			{
				return true;
			}
			
		}
		return false;
		
		
	}
	
	public void CreateSaveFiles()
	{
	
		if(!DirectoryExists())
		{
			CreateDirectory();
			
		}
		
		using (StreamWriter sw = new StreamWriter(Directory + "Test.txt"))
		{
			sw.WriteLine("Testing Clans");
		}
	}

}
