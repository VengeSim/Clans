using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Venge;

namespace Venge{
	
	public struct GridIndex
	{
		public int x;
		public int y;
		public int z;
		
		public GridIndex(int x, int y, int z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}
		public Vector3 ToVector3()
		{
			return new Vector3(this.x, this.y, this.z);
		}
		public override string ToString ()
		{
			return string.Format ("[GridIndex]({0}, {1}, {2})",this.x, this.y, this.z);
		}
		public GridIndex West()
		{
			return new GridIndex(this.x - 1, this.y, this.z);
		}
		public GridIndex East()
		{
			return new GridIndex(this.x + 1, this.y, this.z);
		}
		public GridIndex South()
		{
			return new GridIndex(this.x, this.y, this.z - 1);
		}
		public GridIndex North()
		{
			return new GridIndex(this.x, this.y, this.z + 1);
		}
		public GridIndex Down()
		{
			return new GridIndex(this.x, this.y - 1, this.z);
		}
		public GridIndex Up()
		{
			return new GridIndex(this.x, this.y + 1, this.z);
		}
	}
}
