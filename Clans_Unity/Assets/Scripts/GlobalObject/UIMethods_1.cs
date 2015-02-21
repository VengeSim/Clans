using UnityEngine;
using System.Collections;

public class UIMethods_1 : MonoBehaviour {

	public void LoadScene(string sceneName)
	{
		Application.LoadLevel(sceneName);
	}
	
	public void LoadScene(int sceneNumber)
	{
		Application.LoadLevel(sceneNumber);
	}
}
