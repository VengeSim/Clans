using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Venge;

namespace Venge.Blocks
{
	public class Block
	{
		private static int currentID;
		
		public Vector2 TexturePos;
		public string Name;
		public int ID;
		
		
		static Block()
		{
			currentID = 0;
		}
				
		public Block()
		{
			this.ID = GetNextID();
			this.Name = "Base Block";
			this.TexturePos = new Vector2(0, 0);
		}
		
		protected int GetNextID()
		{
			return ++currentID;
		}
	}
}
