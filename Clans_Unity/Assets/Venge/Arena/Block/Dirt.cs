using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Venge;

namespace Venge.Blocks
{
	public class Dirt : Block
	{
		public Dirt()
		{
			this.Name = "Dirt Block";
			this.TexturePos = new Vector2(1, 0);
		}

		public Dirt(GridIndex index) : base(index)
		{
			this.Name = "Dirt Block";
			this.TexturePos = new Vector2(1, 0);
		}
	}
}
