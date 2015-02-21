//	CameraFacing.cs 
//	original by Neil Carter (NCarter)
//	modified by Hayden Scott-Baron (Dock) - http://starfruitgames.com
//  allows specified orientation axis


using UnityEngine;
using System.Collections;

public class FaceCamera : MonoBehaviour
{
	public Camera mainCamera;
	
	void Start(){
		this.mainCamera = Camera.main;
	}
	void Update()
	{
		
		this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, mainCamera.transform.eulerAngles.y, this.transform.eulerAngles.z);
	}
}
