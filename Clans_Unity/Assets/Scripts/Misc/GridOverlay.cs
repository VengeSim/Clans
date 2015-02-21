using UnityEngine;
using System.Collections;
using Venge;

public class GridOverlay : MonoBehaviour {
		
	public bool showGrid = true;
	
	public int maxX;
	public int maxY;
	public int maxZ;
	
	private int gridSizeX;
	private int gridSizeY;
	private int gridSizeZ;
	
	private float startX = 0f;
	//private float startY = 0f;
	private float startZ = 0f;
	
	private float offsetY = 0;

	private float largeStep = 1f;
	
	private Material lineMaterial;
	
	private Color mainColor = new Color(0f,0f,0f,0.4f);
	
	void Start () 
	{
		gridSizeX = this.maxX;
		gridSizeY = 0;
		gridSizeZ = this.maxZ;
		
	}
	
	void Update () 
	{

	}
	
	void CreateLineMaterial() 
	{
		
		if( !lineMaterial ) {
			lineMaterial = new Material( "Shader \"Lines/Colored Blended\" {" +
			                            "SubShader { Pass { " +
			                            "    Blend SrcAlpha OneMinusSrcAlpha " +
			                            "    ZWrite Off Cull Off Fog { Mode Off } " +
			                            "    BindChannels {" +
			                            "      Bind \"vertex\", vertex Bind \"color\", color }" +
			                            "} } }" );
			lineMaterial.hideFlags = HideFlags.HideAndDontSave;
			lineMaterial.shader.hideFlags = HideFlags.HideAndDontSave;}
	}
	
	void OnPostRender() 
	{        
		CreateLineMaterial();
		// set the current material
		lineMaterial.SetPass( 0 );
		
		GL.Begin( GL.LINES );
		
		if (showGrid)
		{
			GL.Color (mainColor);

			//Layers
			for (float j = 0; j <= gridSizeY; j += largeStep) {
					//X axis lines
					for (float i = 0; i <= gridSizeZ; i += largeStep) {
							GL.Vertex3 (startX, j + offsetY, startZ + i);
							GL.Vertex3 (gridSizeX, j + offsetY, startZ + i);
					}
	
					//Z axis lines
					for (float i = 0; i <= gridSizeX; i += largeStep) {
							GL.Vertex3 (startX + i, j + offsetY, startZ);
							GL.Vertex3 (startX + i, j + offsetY, gridSizeZ);
					}
			}

			//Y axis lines
//			for (float i = 0; i <= gridSizeZ; i += largeStep) {
//					for (float k = 0; k <= gridSizeX; k += largeStep) {
//							GL.Vertex3 (startX + k, startY + offsetY, startZ + i);
//							GL.Vertex3 (startX + k, gridSizeY + offsetY, startZ + i);
//					}
//			}
		}
		
		GL.End();
	}
	
	public void SetSize(Vector3 v3)
	{
		this.gridSizeX = (int)v3.x;
		this.gridSizeY = (int)v3.y;
		this.gridSizeZ = (int)v3.z;
	}
	
	public void Increase()
	{
		if(this.gridSizeY == this.maxY)
		{
			return;
		}
		
		this.gridSizeY++;
	}
	
	public void Decrease()
	{
		if(this.gridSizeY == 0)
		{
			return;
		}
		
		this.gridSizeY--;
	}
}






