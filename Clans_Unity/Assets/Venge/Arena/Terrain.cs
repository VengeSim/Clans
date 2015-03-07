using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Venge;
using Venge.Blocks;


public class Terrain : MonoBehaviour
{
	public int x;
	public int y;
	public int z;
	public int groundLevel;
	public float tUnit;	//For the scale of textures {tileSize/Texturesize = tUnit}
	
	public Block[,,] blockGrid;
	public TerrainMesh mesh;
	
	public void Start()
	{
		
		this.blockGrid = new Block[this.x, this.y, this.z];
		this.tUnit = 0.0625f;
		
		this.mesh = new TerrainMesh(this);
		
		this.Generate();
		this.UpdateMesh();
		
	}
	
	
	public void GenerateTest()
	{
		for(int _x = 0; _x < this.blockGrid.GetLength(0); _x += 1)
		{
			for(int _y = 0; _y < this.blockGrid.GetLength(1); _y += 1)
			{
				for(int _z = 0; _z < this.blockGrid.GetLength(2); _z += 1)
				{
					blockGrid[_x, _y, _z] = new Air();
					
				}
			}
		}
		
		blockGrid[0, 2, 0] = new Dirt();
		blockGrid[0, 0, 0] = new Dirt();
		blockGrid[0, 0, 0] = new Dirt();
		blockGrid[0, 0, 0] = new Dirt();
		
	}
	
	
	public void Generate()
	{
		
		for(int _x = 0; _x < this.blockGrid.GetLength(0); _x += 1)
		{
			for(int _y = 0; _y < this.blockGrid.GetLength(1); _y += 1)
			{
				for(int _z = 0; _z < this.blockGrid.GetLength(2); _z += 1)
				{

					GridIndex index = new GridIndex( _x, _y, _z);

					Block block = new Block(index);
					if (_y == 0)
					{
						block = new Air(index);
					}
					
					if (_y >= groundLevel)
					{
						block = new Air(index);
					}

					if (_y < groundLevel)
					{
						int r = Venge.Random.DiceRoll();
						
						if (r > 3)
						{
							block = new Air(index);
						}else{
							block = new Dirt(index);
						}
					}
					
					
					
					blockGrid[_x, _y, _z] = block;
				}
			}
		}
	}
	
	
	//Redraws the mesh
	//only drawing block sides that boader Air blocks
	public void UpdateMesh()
	{
		for(int _x = 0; _x < this.blockGrid.GetLength(0); _x += 1)
		{
			for(int _y = 0; _y < this.blockGrid.GetLength(1); _y += 1)
			{
				for(int _z = 0; _z < this.blockGrid.GetLength(2); _z += 1)
				{
					
					GridIndex gridIndex = new GridIndex(_x, _y, _z);
					//Debug.Log(gridIndex.ToString());
					Block block = this.GetBlock(gridIndex);
					if (!(block is Air))
					{
						if (this.IsValidIndex(gridIndex.West()))
						{
							if (this.GetBlock(gridIndex.West()) is Air)
							{
								mesh.CubeLeft(gridIndex, block);
							}
						}else{
							mesh.CubeLeft(gridIndex, block);
						}
						
						if (this.IsValidIndex(gridIndex.East()))
						{
							if (this.GetBlock(gridIndex.East()) is Air)
							{
								mesh.CubeRight(gridIndex, block);
							}
						}else{
							mesh.CubeRight(gridIndex, block);
						}
						
						if (this.IsValidIndex(gridIndex.North()))
						{	
							if (this.GetBlock(gridIndex.North()) is Air)
							{
								mesh.CubeForward(gridIndex, block);
							}
						}else{
							mesh.CubeForward(gridIndex, block);
						}
						
						if (this.IsValidIndex(gridIndex.South()))
						{	
							if (this.GetBlock(gridIndex.South()) is Air)
							{
								mesh.CubeBackward(gridIndex, block);
							}
						}else{
							mesh.CubeBackward(gridIndex, block);
						}
						
						if (this.IsValidIndex(gridIndex.Up()))
						{
							if (this.GetBlock(gridIndex.Up()) is Air)
							{
								mesh.CubeTop(gridIndex, block);
							}
						}else{
							mesh.CubeTop(gridIndex, block);
						}
						
						if (this.IsValidIndex(gridIndex.Down()))
						{
							if (this.GetBlock(gridIndex.Down()) is Air)
							{
								mesh.CubeBottom(gridIndex, block);
							}
						}else{
							mesh.CubeBottom(gridIndex, block);
						}
					}
				}
			}
		}
		mesh.UpdateMesh();
	} 
	
	
	public void SetBlock(Block block, GridIndex gridIndex)
	{
		this.blockGrid[gridIndex.x, gridIndex.y, gridIndex.z] = block;
	}
	
	public Block GetBlock(GridIndex gridIndex)
	{
		Block block = this.blockGrid[gridIndex.x, gridIndex.y, gridIndex.z];
		return block;
	}
	
	public bool IsValidIndex(int x, int y, int z)
	{
		if (
				x >= 0 && 
				y >= 0 && 
				z >= 0 && 
				x < this.x && 
				y < this.y && 
				z < this.z
			)
		{
			return true;
		}else{
			return false;
		}
	} 
	public bool IsValidIndex(GridIndex index)
	{
		return this.IsValidIndex(index.x, index.y, index.z);
	} 
}










public class TerrainMesh
{
	public List<Vector3> newVertices = new List<Vector3>();
	public List<int> newTriangles = new List<int>();
	public List<Vector2> newUV = new List<Vector2>();
	private Mesh mesh;
	public int faceCount;
	private float tUnit;
	
	
	public TerrainMesh(Terrain terrain)
	{
		this.mesh = terrain.gameObject.GetComponent<MeshFilter> ().mesh;
		
		this.faceCount = 0;
		tUnit = terrain.tUnit;		
	}
	
	public void CubeTop (GridIndex gridIndex, Block block)
	{
		this.newVertices.Add(new Vector3 (gridIndex.x,  gridIndex.y,  gridIndex.z + 1));
		this.newVertices.Add(new Vector3 (gridIndex.x + 1, gridIndex.y,  gridIndex.z + 1));
		this.newVertices.Add(new Vector3 (gridIndex.x + 1, gridIndex.y,  gridIndex.z ));
		this.newVertices.Add(new Vector3 (gridIndex.x,  gridIndex.y,  gridIndex.z ));
		
		Vector2 texturePos = block.TexturePos;
		
		this.Cube(texturePos);
	}
	public void CubeForward (GridIndex gridIndex, Block block)
	{
		this.newVertices.Add(new Vector3 (gridIndex.x + 1, gridIndex.y - 1, gridIndex.z + 1));
		this.newVertices.Add(new Vector3 (gridIndex.x + 1, gridIndex.y, gridIndex.z + 1));
		this.newVertices.Add(new Vector3 (gridIndex.x, gridIndex.y, gridIndex.z + 1));
		this.newVertices.Add(new Vector3 (gridIndex.x, gridIndex.y - 1, gridIndex.z + 1));
		
		Vector2 texturePos = block.TexturePos;
		
		this.Cube(texturePos);
	}
	public void CubeRight (GridIndex gridIndex, Block block)
	{
		this.newVertices.Add(new Vector3 (gridIndex.x + 1, gridIndex.y - 1, gridIndex.z));
		this.newVertices.Add(new Vector3 (gridIndex.x + 1, gridIndex.y, gridIndex.z));
		this.newVertices.Add(new Vector3 (gridIndex.x + 1, gridIndex.y, gridIndex.z + 1));
		this.newVertices.Add(new Vector3 (gridIndex.x + 1, gridIndex.y - 1, gridIndex.z + 1));
		
		Vector2 texturePos = block.TexturePos;
		
		this.Cube(texturePos);
	}
	public void CubeBackward (GridIndex gridIndex, Block block)
	{
		this.newVertices.Add(new Vector3 (gridIndex.x, gridIndex.y - 1, gridIndex.z));
		this.newVertices.Add(new Vector3 (gridIndex.x, gridIndex.y, gridIndex.z));
		this.newVertices.Add(new Vector3 (gridIndex.x + 1, gridIndex.y, gridIndex.z));
		this.newVertices.Add(new Vector3 (gridIndex.x + 1, gridIndex.y - 1, gridIndex.z));
		
		Vector2 texturePos = block.TexturePos;
		
		this.Cube(texturePos);
	}
	public void CubeLeft (GridIndex gridIndex, Block block)
	{
		this.newVertices.Add(new Vector3 (gridIndex.x, gridIndex.y- 1, gridIndex.z + 1));
		this.newVertices.Add(new Vector3 (gridIndex.x, gridIndex.y, gridIndex.z + 1));
		this.newVertices.Add(new Vector3 (gridIndex.x, gridIndex.y, gridIndex.z));
		this.newVertices.Add(new Vector3 (gridIndex.x, gridIndex.y - 1, gridIndex.z));
		
		Vector2 texturePos = block.TexturePos;
		
		this.Cube(texturePos);
	}
	public void CubeBottom (GridIndex gridIndex, Block block)
	{
		this.newVertices.Add(new Vector3 (gridIndex.x,  gridIndex.y - 1,  gridIndex.z ));
		this.newVertices.Add(new Vector3 (gridIndex.x + 1, gridIndex.y - 1,  gridIndex.z ));
		this.newVertices.Add(new Vector3 (gridIndex.x + 1, gridIndex.y - 1,  gridIndex.z + 1));
		this.newVertices.Add(new Vector3 (gridIndex.x,  gridIndex.y - 1,  gridIndex.z + 1));
		
		Vector2 texturePos = block.TexturePos;
		
		this.Cube(texturePos);
		
	}
	public void Cube (Vector2 texturePos) {
		
		this.newTriangles.Add(faceCount * 4  ); //1
		this.newTriangles.Add(faceCount * 4 + 1 ); //2
		this.newTriangles.Add(faceCount * 4 + 2 ); //3
		this.newTriangles.Add(faceCount * 4  ); //1
		this.newTriangles.Add(faceCount * 4 + 2 ); //3
		this.newTriangles.Add(faceCount * 4 + 3 ); //4
		
		newUV.Add(new Vector2 (tUnit * texturePos.x + tUnit, tUnit * texturePos.y));
		newUV.Add(new Vector2 (tUnit * texturePos.x + tUnit, tUnit * texturePos.y + tUnit));
		newUV.Add(new Vector2 (tUnit * texturePos.x, tUnit * texturePos.y + tUnit));
		newUV.Add(new Vector2 (tUnit * texturePos.x, tUnit * texturePos.y));
		
		this.faceCount++; // Add this line
	}
	
	public void UpdateMesh()
	{
		this.mesh.Clear ();
		this.mesh.vertices = newVertices.ToArray();
		this.mesh.uv = newUV.ToArray();
		this.mesh.triangles = newTriangles.ToArray();
		this.mesh.Optimize ();
		this.mesh.RecalculateNormals ();
		
		this.newVertices.Clear();
		this.newUV.Clear();
		this.newTriangles.Clear();
		
		this.faceCount=0;
	}
}

